import { Component, OnInit, ViewChild, ɵbypassSanitizationTrustResourceUrl } from '@angular/core';
import { EmployeeService } from '../shared/employee.service';
import { Employee } from '../shared/employee.model';
import { DatePipe } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { EmployeeFormComponent } from './employee-form/employee-form.component';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {

  constructor(public empService:EmployeeService, public datepipe:DatePipe, public toast:ToastrService){}
  @ViewChild(EmployeeFormComponent) emp:EmployeeFormComponent;
  ngOnInit() {
    this.empService.getEmployees().subscribe(data=>{
      this.empService.listEmployee=data;
    });
  }

  populateEmployee(selectedEmployee:Employee){
    let df=this.datepipe.transform(selectedEmployee.doj,'yyyy-MM-dd');
    selectedEmployee.doj=df;
    this.empService.employeeData=selectedEmployee;

    if(this.emp.isSlide==='off'){
      this.emp.hideShowSlide();
    }
  }

  delete(id:number){
    if(confirm('Are you really want to delete this record?')){
      this.empService.deleteEmployee(id).subscribe(data=>{
        this.empService.getEmployees().subscribe(data=>{
          this.empService.listEmployee=data;
          this.toast.error('Success','Record Deleted Successfully');
        });
      },
      err=>{
        this.toast.error('Success','Record Not Deleted Successfully');
      });
    }
  }
}
