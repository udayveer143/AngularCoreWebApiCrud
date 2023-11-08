import { createMayBeForwardRefExpression } from '@angular/compiler';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Employee } from 'src/app/shared/employee.model';
import { EmployeeService } from 'src/app/shared/employee.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {
  constructor(public empService:EmployeeService, public toast:ToastrService){}
  @ViewChild('checkbox1') checkBox:ElementRef;
  isSlide:string='off';
  ngOnInit(){
    this.empService.getDesignations().subscribe(data=>{
      this.empService.listDesignation=data;
    });
  }

  submit(form:NgForm){
    this.empService.employeeData.isMarried=form.value.isMarried==true?1:0;
    this.empService.employeeData.isActive=form.value.isActive==true?1:0;

    if(this.empService.employeeData.id==0){
      this.insertEmployee(form);
    }
    else{
      this.updateEmployee(form);
    }
  }

  insertEmployee(myForm:NgForm){
    this.empService.saveEmployee().subscribe(d=>{
      this.resetForm(myForm);
      this.refreshData();
      this.toast.success('Success','Record Saved Successfully');
    });

  }

  updateEmployee(myForm:NgForm){
    this.empService.updateEmployee().subscribe(d=>{
      this.resetForm(myForm);
      this.refreshData();
      this.toast.warning('Success','Record Updated Successfully');
    });

  }

  resetForm(myForm:NgForm){
    myForm.form.reset(myForm.value);
    this.empService.employeeData=new Employee();
    this.hideShowSlide();
  }

  refreshData(){
    this.empService.getEmployees().subscribe(res=>{
      this.empService.listEmployee=res;
    });
  }

  onDesignationChange(event:any){
    if(typeof event.target.value=="string"){
       this.empService.employeeData.designationId=parseInt(event.target.value);
    }
  }

  hideShowSlide(){
    if(this.checkBox.nativeElement.checked){
      this.checkBox.nativeElement.checked=false;
      this.isSlide='off';
    }
    else{
      this.checkBox.nativeElement.checked=true;
      this.isSlide='on';
    }
  }
}
