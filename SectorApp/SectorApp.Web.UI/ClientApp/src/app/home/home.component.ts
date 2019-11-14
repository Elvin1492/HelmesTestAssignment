import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  dropdownList = [];
  selectedItems = [];
  dropdownSettings = {};
  success = false;
  userForm: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.userForm = this.fb.group({
      Id: 0,
      Name: ['', Validators.required],
      Sectors: [[], Validators.required],
      AgreeAndTerms: [false, Validators.required]
    });
  }

  ngOnInit(): void {
    this.http.get<any>('http://localhost:64965/api/sector/getsectors').subscribe(data => {
      this.dropdownList = data;
    });
   
    this.selectedItems = [
     
    ];
    this.dropdownSettings = {
      singleSelection: false,
      text: "Select Sectors",
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      enableSearchFilter: true,
      primaryKey: "Id",
      labelKey: "Name",
      searchBy: ['Name']
    };           
  }

  submitForm() {
    console.warn(this.userForm.value);
    this.http.post<any>('http://localhost:64965/api/appuser/create', this.userForm.value).subscribe(data => {
      this.userForm.patchValue({
        Id: data.Id
      });
      this.success = true;
      setTimeout(() => {
        this.success = false;
      }, 10000);
    }, error => {
      console.log(error);
    });
  }

  onItemSelect(item: any) {
    console.log(item);
    console.log(this.selectedItems);
  }
  OnItemDeSelect(item: any) {
    console.log(item);
    console.log(this.selectedItems);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
  onDeSelectAll(items: any) {
    console.log(items);
  }
}
