import { Component, OnInit, ViewChild, ViewChildren, ViewEncapsulation} from '@angular/core';
import { UntypedFormGroup, FormControl, UntypedFormBuilder, Validators} from '@angular/forms';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Chacrona } from './chacrona.model';
import { TranslateService } from '@ngx-translate/core';
import { environment } from 'src/environments/environment';
import { MenuService } from 'src/app/theme/components/menu/menu.service';
import { ImageUploaderComponent } from 'src/app/pages/form-elements/controls/image-uploader/image-uploader.component';
import { ChacronaService } from './chacrona.service';

@Component({
  selector: 'app-chacrona',
  templateUrl: './chacrona.component.html',
  styleUrls: ['./chacrona.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [ ChacronaService, MenuService ]
})
export class ChacronaComponent implements OnInit {

  @ViewChildren(ImageUploaderComponent) imageUpload: ImageUploaderComponent;

  // public menuItems:Array<any>;
  public caminhoImagem = environment.apiURL + "/resources/images";
  public chacrona: Chacrona;
  public chacronas: Chacrona[];

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
              public chacronaService:ChacronaService,
              public menuService:MenuService,
              public modalService: NgbModal) {

  }

  ngOnInit() {
    // this.getUsers();
    this.getChacrona();

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


  public getChacrona(): void {
    this.chacronaService.getChacrona().subscribe( chacronas =>
      this.chacronas = chacronas
    );
  }

  public addChacrona(chacrona:Chacrona){
    this.chacronaService.addChacrona(chacrona).subscribe(chacrona => {
      this.getChacrona();
    });
  }


  public updateChacrona(chacrona:Chacrona){
    this.chacronaService.updateChacrona(chacrona).subscribe(chacrona => {
      this.getChacrona();
    });
  }


  public deleteChacrona(chacrona:Chacrona){
    this.chacronaService.deleteChacrona(chacrona.id).subscribe(result =>
      this.getChacrona()
    );
  }

  // public toggle(type){
  //   this.type = type;
  // }

  public openModal(modalContent, chacrona) {
    if(chacrona){
      this.chacrona = chacrona;
      this.image = this.caminhoImagem + "/" + chacrona.imagem;
      this.form.setValue(chacrona);

    }
    else{
      this.chacrona = new Chacrona();
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

  public onSubmit(chacrona:Chacrona):void {
    if (this.form.valid) {
      chacrona.arquivo = this.file;
      if(chacrona.id){
        this.updateChacrona(chacrona);
      }
      else{
        this.addChacrona(chacrona);
      }
      this.removeImage();
      this.modalRef.close();
    }
  }

}
