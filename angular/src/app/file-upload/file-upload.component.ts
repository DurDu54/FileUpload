import { Component, Injector, OnInit, TemplateRef } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { AppComponentBase } from '@shared/app-component-base';
import { AppConsts } from '@shared/AppConsts';
import { FileParameter, FileUploadServiceServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent  extends AppComponentBase {
  baseUrl:string = AppConsts.remoteServiceBaseUrl+"/";
  filePaths :string[];
  resimPath:string;
  tamEkran?: BsModalRef;
  
  constructor(
    private _storageServiceProxy : FileUploadServiceServiceProxy,
    private modalService: BsModalService,
    injector : Injector,
  ) { 
    super(injector);
  }

  ngOnInit(): void {
    this.getFile();
  }
  
  readUrl(event : any){
    const files =event.target.files;
    if(files && files[0]){
      const file : File=event.target.files[0];
      if (file) {
        let fileParameter : FileParameter={data : file , fileName :file.name};
        let array :Array<FileParameter>=[fileParameter];
        this._storageServiceProxy.upload(array).subscribe((res) =>{             
        })
        this.getFile();
      }
    }
    
  }

  getFile(){
    this._storageServiceProxy.getFiles()
      .subscribe((res) => {
        this.filePaths=res;
    });   
  }
  protected delete(path : string): void {
    abp.message.confirm(
      this.l('Buradaki dosya siliniyor', path),
      undefined,
      (result: boolean) => {
        if (result) {
          this._storageServiceProxy.delete(path).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.getFile();
          });
        }
      }
    );
  }
  openModal(template: TemplateRef<any>,path:string) {
    this.resimPath=path;
    //this.tamEkran = this.modalService.show(template);
  }
}
