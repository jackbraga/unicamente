import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-image-uploader',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './image-uploader.component.html',
  styleUrls: ['./image-uploader.component.scss']
})
export class ImageUploaderComponent implements OnInit{
    public image:any;
    public file: File;

    ngOnInit(): void{}

    fileChange(input){
        const reader = new FileReader();
        if (input.files.length) {
             this.file = input.files[0];
            reader.onload = () => {
                this.image = reader.result;
            }
            reader.readAsDataURL(this.file);
        }
    }

    removeImage():void{
        this.image = '';
    }

}

