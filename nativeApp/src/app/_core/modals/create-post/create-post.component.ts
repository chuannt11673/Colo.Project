import { concatMap } from 'rxjs/operators';
import { PostService } from './../../../_services/post.service';
import { FileService } from './../../../_services/file.service';
import { TranslateConfigService } from './../../services/translate-config.service';
import { ModalController } from '@ionic/angular';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.scss'],
})
export class CreatePostComponent implements OnInit {

  constructor(public modalController: ModalController,
    public translateConfigService: TranslateConfigService,
    private fileService: FileService,
    private postService: PostService) { }

  @ViewChild('textBox') textBox: ElementRef;
  images: any[] = [];

  ngOnInit() { }

  dismiss() {
    this.modalController.dismiss();
  }

  onSelectImage(base64: string) {
    this.images.push({
      base64: base64,
      src: `data:image/jpeg;base64,${base64}`
    })
  }

  send() {
    let content = this.textBox.nativeElement.innerHTML;

    if (!content)
      return;

    let images = this.images.map(x => {
      return {
        base64: x.src
      }
    });

    if (images.length > 0) {
      this.fileService.uploadMultiple(images)
        .pipe(concatMap((files: any[]) => {
          let fileIds = files.map(res => res.id);

          let model = {
            content: content,
            fileIds: fileIds
          };

          return this.postService.create(model);
        }))
        .subscribe(res => {
          this.modalController.dismiss(res);
        });
    }
    else {
      let model = {
        content: content,
        fileIds: []
      };

      this.postService.create(model).subscribe(res => {
        this.modalController.dismiss(res);
      });
    }
  }
}
