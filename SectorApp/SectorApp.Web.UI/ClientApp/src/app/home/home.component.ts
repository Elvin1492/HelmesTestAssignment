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

  userForm: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  createForm() {
    this.userForm = this.fb.group({

    });
  }

  ngOnInit(): void {
    this.http.get<any>('http://localhost:64965/api/sector/getsectors').subscribe(data => {
      this.dropdownList = data;
    });
   
    this.selectedItems = [
      //{ "Id": 2, "Name": "Singapore" },
      //{ "Id": 3, "Name": "Australia" },
      //{ "Id": 4, "Name": "Canada" },
      //{ "Id": 5, "Name": "South Korea" }
    ];
    this.dropdownSettings = {
      singleSelection: false,
      text: "Select Countries",
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      enableSearchFilter: true,
      classes: "myclass custom-class",
      primaryKey: "Id",
      labelKey: "Name",
      searchBy: ['Name']
    };           
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
