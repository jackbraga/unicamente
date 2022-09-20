import { Component, OnInit, ViewChild, ViewChildren, ViewEncapsulation} from '@angular/core';
import { UntypedFormGroup, FormControl, UntypedFormBuilder, Validators} from '@angular/forms';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Mariri } from './mariri.model';
import { MaririService } from './mariri.service';
import { TranslateService } from '@ngx-translate/core';
import { environment } from 'src/environments/environment';
import { MenuService } from 'src/app/theme/components/menu/menu.service';
import { ImageUploaderComponent } from 'src/app/pages/form-elements/controls/image-uploader/image-uploader.component';

@Component({
  selector: 'app-mariri',
  templateUrl: './mariri.component.html',
  styleUrls: ['./mariri.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [ MaririService, MenuService ]
})
export class MaririComponent implements OnInit {

  @ViewChildren(ImageUploaderComponent) imageUpload: ImageUploaderComponent;

  // public menuItems:Array<any>;
  public caminhoImagem = environment.apiURL + "/resources/images";
  public mariri: Mariri;
  public mariris: Mariri[];

  public searchText: string;
  public p:any;
  // public type:string = 'grid';
  public modalRef: NgbModalRef;
  public form:UntypedFormGroup;

  imagemURL = 'assets/img/upload.png';
  file: File;
  public image:any;


  constructor(public fb:UntypedFormBuilder,
              public toastrService: ToastrService,
              public translateService: TranslateService,
              public maririService:MaririService,
              public menuService:MenuService,
              public modalService: NgbModal) {

  }

  ngOnInit() {
    // this.getUsers();
    this.getMariri();

    this.form = this.fb.group({
        id: 0,
        descricao: [null, Validators.compose([Validators.required, Validators.minLength(5)])],
        observacao: null,
        imagem: null,
        arquivo: null,
    });
  }


  fileChange(input){
    const reader = new FileReader();
    if (input.target.files.length) {
         this.file = input.target.files[0];
        reader.onload = () => {
            this.image = reader.result;
        }
        reader.readAsDataURL(this.file);
    }
}

removeImage():void{
    this.image = '';
}


  public getMariri(): void {
    this.maririService.getMariri().subscribe( mariris =>
      this.mariris = mariris
    );
  }

  public addMariri(mariri:Mariri){
    this.maririService.addMariri(mariri).subscribe(mariri => {
      this.getMariri();
    });
  }


  public updateMariri(mariri:Mariri){
    this.maririService.updateMariri(mariri).subscribe(mariri => {
      this.getMariri();
    });
  }


  public deleteMariri(mariri:Mariri){
    this.maririService.deleteMariri(mariri.id).subscribe(result =>
      this.getMariri()
    );
  }

  // public toggle(type){
  //   this.type = type;
  // }

  public openModal(modalContent, mariri) {
    if(mariri){
      this.mariri = mariri;
      this.image = this.caminhoImagem + "/" + mariri.imagem;
      this.form.setValue(mariri);

    }
    else{
      this.mariri = new Mariri();
      this.removeImage();
      // this.form.setValue(mariri);
    }
    this.modalRef = this.modalService.open(modalContent, { container: '.app' });

    this.modalRef.result.then((result) => {
      this.form.reset();
    }, (reason) => {
      this.form.reset();
    });
  }

  public closeModal(){
    this.modalRef.close();
    this.form.reset();

  }

  public onSubmit(mariri:Mariri):void {
    if (this.form.valid) {
      mariri.arquivo = this.file;
      if(mariri.id){
        this.updateMariri(mariri);
      }
      else{
        this.addMariri(mariri);
      }
      this.removeImage();
      this.modalRef.close();
    }
  }

}
