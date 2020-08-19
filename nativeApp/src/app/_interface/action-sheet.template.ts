import { UserService } from './../_services/user.service';
import { FileService } from './../_services/file.service';
import { ImageReviewComponent } from './../_core/modals/image-review/image-review.component';
import { Camera } from '@ionic-native/Camera/ngx';
import { ActionSheetController, ModalController } from '@ionic/angular';
import { Injectable } from '@angular/core';
import { AuthService } from '../_core/services/auth.service';

export abstract class ActionSheetTemplate {

    constructor(protected actionSheetController: ActionSheetController) { }

    async presentAsync() {
        let modal = this.createModal();
        const actionSheet = await this.actionSheetController.create(modal);
        await actionSheet.present();
    }

    protected abstract createModal(): any;
}

@Injectable()
export class LogoutActionSheet extends ActionSheetTemplate {

    constructor(protected actionSheetController: ActionSheetController, private authService: AuthService) {
        super(actionSheetController);
    }

    public createModal() {
        return {
            header: "Log out this account?",
            buttons: [
                {
                    text: 'Log out',
                    cssClass: 'danger',
                    handler: () => {
                        this.authService.signOut();
                    }
                },
                {
                    text: 'Cancel',
                    role: 'cancel'
                }
            ]
        };
    }
}

@Injectable()
export class UploadProfileActionSheet extends ActionSheetTemplate {

    base64: string;
    constructor(protected actionSheetController: ActionSheetController, private camera: Camera, private modalController: ModalController,
        private fileService: FileService, private userService: UserService) {
        super(actionSheetController);
    }

    createModal() {
        return {
            header: "Image",
            buttons: [
                {
                    text: 'Take photo',
                    cssClass: 'primary',
                    handler: () => { this.takePhoto(); }
                },
                {
                    text: 'Choose from photos',
                    cssClass: 'primary',
                    handler: () => { this.chooseFromPhotos(); }
                },
                {
                    text: 'Cancel',
                    role: 'cancel'
                }
            ]
        };
    }

    private takePhoto() {
        this.pickImage(this.camera.PictureSourceType.CAMERA);
    }

    private chooseFromPhotos() {
        this.pickImage(this.camera.PictureSourceType.PHOTOLIBRARY);
    }

    private pickImage(sourceType: any) {
        const options = {
            quality: 80,
            sourceType: sourceType,
            destinationType: this.camera.DestinationType.DATA_URL,
            encodingType: this.camera.EncodingType.JPEG,
            mediaType: this.camera.MediaType.PICTURE,
            correctOrientation: true
        };

        this.camera.getPicture(options).then((imageData) => {
            this.base64 = imageData;
            this.presentModal();
        }, err => {});
    }

    private async presentModal() {
        const modal = await this.modalController.create({
          component: ImageReviewComponent,
          componentProps: {
            'base64': this.base64
          }
        });

        await modal.present();
        const { data } = await modal.onWillDismiss();

        if (data)
            this.uploadPicture(data.message, this.base64);
    }

    private uploadPicture(message:string, base64: string) {
        this.fileService.upload({ base64: base64 }).subscribe(res => {
          this.send({ message: message }, res);
        });
    }

    private send(event: any, file: any) {
        this.userService.updateUserProfileImage({ fileId: file.id }).subscribe(res => {
        });
    }
}

@Injectable()
export class UploadCoverActionSheet extends ActionSheetTemplate {

    base64: string;
    constructor(protected actionSheetController: ActionSheetController, private camera: Camera, private modalController: ModalController,
        private fileService: FileService, private userService: UserService) {
        super(actionSheetController);
    }

    createModal() {
        return {
            header: "Cover",
            buttons: [
                {
                    text: 'Take photo',
                    cssClass: 'primary',
                    handler: () => { this.takePhoto(); }
                },
                {
                    text: 'Choose from photos',
                    cssClass: 'primary',
                    handler: () => { this.chooseFromPhotos(); }
                },
                {
                    text: 'Cancel',
                    role: 'cancel'
                }
            ]
        };
    }

    private takePhoto() {
        this.pickImage(this.camera.PictureSourceType.CAMERA);
    }

    private chooseFromPhotos() {
        this.pickImage(this.camera.PictureSourceType.PHOTOLIBRARY);
    }

    private pickImage(sourceType: any) {
        const options = {
            quality: 80,
            sourceType: sourceType,
            destinationType: this.camera.DestinationType.DATA_URL,
            encodingType: this.camera.EncodingType.JPEG,
            mediaType: this.camera.MediaType.PICTURE,
            correctOrientation: true
        };

        this.camera.getPicture(options).then((imageData) => {
            this.base64 = imageData;
            this.presentModal();
        }, err => {});
    }

    private async presentModal() {
        const modal = await this.modalController.create({
          component: ImageReviewComponent,
          componentProps: {
            'base64': this.base64
          }
        });

        await modal.present();
        const { data } = await modal.onWillDismiss();
        if (data)
            this.uploadPicture(data.message, this.base64);
    }

    private uploadPicture(message:string, base64: string) {
        this.fileService.upload({ base64: base64 }).subscribe(res => {
          this.send({ message: message }, res);
        });
    }

    private send(event: any, file: any) {
        this.userService.updateUserCover({ fileId: file.id }).subscribe(res => {
        });
    }
}