import { Component, ElementRef, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { ModalController, ActionSheetController } from '@ionic/angular';
import { EmojiService } from '@ctrl/ngx-emoji-mart/ngx-emoji';
import { Keyboard } from '@ionic-native/keyboard/ngx';
import { Camera } from '@ionic-native/Camera/ngx';

@Component({
  selector: 'app-message-box',
  templateUrl: './message-box.component.html',
  styleUrls: ['./message-box.component.scss'],
})
export class MessageBoxComponent implements OnInit {
  sourceType: number;
  isShowEmoji = false;
  imageBase64Items: any[] = [];
  isInput: boolean = false;

  actionArea: HTMLElement;
  actionHeight: number;

  backgroundImageFn = (set: string, sheetSize: number) => '/assets/images/icons-v3.png';

  private newNode: any;
  private sourceTypes = {
    library: 1,
    video: 2
  }

  @Input() disableImageSelection: boolean = false;
  @Input() disableVideoSelection: boolean = false;
  @Input() disableTextBox: boolean = false;
  @Input() disableSendBtn: boolean = false;
  @Input() oDoc: HTMLDivElement;
  @Output() onSend: EventEmitter<any> = new EventEmitter();
  @Output() onSelectEmoji: EventEmitter<any> = new EventEmitter();
  @Output() onSelectImage: EventEmitter<string> = new EventEmitter();

  constructor(private ele: ElementRef, private modalController: ModalController, private emoji: EmojiService, public keyboard: Keyboard,
    private camera: Camera, public actionSheetController: ActionSheetController) {
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.subscribeKeyboard();
    if (!this.oDoc)
      this.oDoc = this.ele.nativeElement.querySelector('#textBox');

    if (this.oDoc) {
      this.oDoc.addEventListener('focus', () => { this.isInput = true; });
      this.oDoc.addEventListener('blur', () => { if (!this.oDoc.innerHTML) this.isInput = false; });
    }

    this.actionArea = this.ele.nativeElement.querySelector('.action-area') as HTMLElement;
    this.actionHeight = -this.actionArea.offsetHeight - 56;
    this.resetTopStyle();
  }

  ionViewDidEnter() {
    if (this.sourceType) {
      if (this.sourceType == this.sourceTypes.library)
        this.selectImage();
    }
  }

  subscribeKeyboard() {
    window.addEventListener('keyboardWillShow', (event) => {
      this.isShowEmoji = false;
      this.resetTopStyle();
    });
  }

  onChangeEmoji() {
    this.isShowEmoji = !this.isShowEmoji;
    this.resetTopStyle();
  }

  resetTopStyle() {
    if (this.isShowEmoji) {
      this.actionArea.style.top = `${this.actionHeight}px`;
      this.actionArea.parentElement.style.marginTop = `${Math.abs(this.actionHeight)}px`;
    }
    else {
      this.actionArea.style.top = '-56px';
      this.actionArea.parentElement.style.marginTop = '56px';
    }
  }

  addEmoji(event: any) {
    if (this.disableTextBox && !this.oDoc) {
      this.onSelectEmoji.emit(event);
      return;
    }

    this.newNode = document.createElement('span');
    this.newNode.innerHTML = '&nbsp;';
    let emoji = this.createEmojiHtml(event.emoji);
    this.insertTextAtCursor(emoji);
    this.insertAfter(emoji);
    this.focus(() => this.oDoc.blur());
  }

  insertTextAtCursor(node: Node) {
    let range: Range, sel = window.getSelection();
    if (sel.getRangeAt && sel.rangeCount && this.oDoc.contains(sel.focusNode)) {
      range = sel.getRangeAt(0);
      range.insertNode(node);
    }
    else {
      this.oDoc.appendChild(node);
    }
  }

  focus(callback: Function = null) {
    if (!this.newNode) return;

    var range = document.createRange();
    var sel = window.getSelection();
    range.setStart(this.newNode, 1);
    range.collapse(true);
    sel.removeAllRanges();
    sel.addRange(range);

    if (callback)
      callback();
  }

  createEmojiHtml(emoji: any) {
    const el = document.createElement('div');
    Object.assign(el.style, this.createStyles(emoji));
    return el;
  }

  createStyles(emoji: any) {
    const styles = this.emoji.emojiSpriteStyles(emoji.sheet, 'twitter');
    styles['margin'] = '0';
    styles['vertical-align'] = 'middle';
    return styles;
  }

  insertAfter(referenceNode: any) {
    referenceNode.parentNode.insertBefore(this.newNode, referenceNode.nextSibling);
  }

  dismiss() {
    this.modalController.dismiss({
      'dismissed': true
    });
  }

  post() {
    let returnVal = {
      message: this.oDoc.innerHTML,
      imageBase64Items: this.imageBase64Items
    };
    this.onSend.next(returnVal);
    this.oDoc.innerHTML = null;
    this.onChangeEmoji();
  }

  //#region image picker
  pickImage(sourceType: any) {
    const options = {
      quality: 80,
      sourceType: sourceType,
      destinationType: this.camera.DestinationType.DATA_URL,
      encodingType: this.camera.EncodingType.JPEG,
      mediaType: this.camera.MediaType.PICTURE,
      correctOrientation: true
    };

    this.camera.getPicture(options).then((imageData) => {
      let base64Image = 'data:image/jpeg;base64,' + imageData;
      this.imageBase64Items.push(base64Image);
      this.onSelectImage.emit(base64Image);
    }, (err) => {
    });
  }

  async selectImage() {
    const actionSheet = await this.actionSheetController.create({
      header: "Select Image source",
      buttons: [{
        text: 'Load from Library',
        handler: () => {
          this.pickImage(this.camera.PictureSourceType.PHOTOLIBRARY);
        }
      },
      {
        text: 'Use Camera',
        handler: () => {
          this.pickImage(this.camera.PictureSourceType.CAMERA);
        }
      },
      {
        text: 'Cancel',
        role: 'cancel'
      }
      ]
    });
    await actionSheet.present();
  }
  //#endregion
}
