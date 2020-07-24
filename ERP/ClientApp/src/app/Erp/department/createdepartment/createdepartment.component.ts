import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder, FormControl, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-createdepartment',
  templateUrl: './createdepartment.component.html',
  styleUrls: ['./createdepartment.component.css']
})
export class CreatedepartmentComponent implements OnInit {

  departmentForm:FormGroup;
  
  constructor(private fb:FormBuilder) { }

  ngOnInit(): void {
    this.departmentFormInit();
  }

  onSubmit():void{
    console.log(this.departmentForm.value);
  }

  /*departmentFormInit():void{
    this.departmentForm=new FormGroup({
      fullName:new FormControl(),
      email:new FormControl(),
      skills:new FormGroup({
        skillName:new FormControl(),
        experinceInYears:new FormControl(),
        proficiency:new FormControl()
      })
    });
  }*/

  departmentFormInit():void{
    this.departmentForm=this.fb.group({
      fullName:['',[Validators.required,Validators.minLength(2),Validators.maxLength(10)]],
      email:['',[Validators.required, this.emailDomain('gmail.com')]],
      phone:['',Validators.required],
      skills:this.fb.group({
        skillName:['',Validators.required],
        experinceInYears:['',Validators.required],
        proficiency:['',Validators.required]
      })
    });


    /*this.departmentForm.get('phone').valueChanges.subscribe((value:string)=>{
      this.manageValidators(value);
    });*/

    this.departmentForm.valueChanges.subscribe(
      (data)=>{
        this.logValidationErrors(this.departmentForm);
      }
    );
  }


  onBind():void{
    /*this.departmentForm.setValue({
      fullName:'amr',
      email:'amr@gmail.com',
      skills:{
        skillName:'C#',
        experinceInYears:'5',
        proficiency:'Advanced'
      }
    });*/

    this.logValidationErrors(this.departmentForm);
    console.log(this.formErrors);
  }


  manageValidators(key:string):void{
    const control= this.departmentForm.get(key);
    control.setValidators([
      Validators.required,
      Validators.minLength(3)
    ]);

    //control.clearValidators();

    //must calling 
    control.updateValueAndValidity();

  }

  logValidationErrors(group:FormGroup = this.departmentForm):void{
    Object.keys(group.controls).forEach((key)=>{
      const abstractControl= group.get(key);
      if(abstractControl instanceof FormGroup){
        this.logValidationErrors(abstractControl);
      }else{
        this.formErrors[key]='';
        if(abstractControl.touched && abstractControl.invalid && 
          (abstractControl.touched || abstractControl.dirty)){
          const messages= this.validationMessages[key];
          for(let errorKey in abstractControl.errors){
            if(errorKey){
              this.formErrors[key]+=messages[errorKey]+'  ';
            }
          }
        }
      }
    });
  }


  formErrors={
    'fullName':'',
    'email':'',
    'phone':'',
    'skillName':'',
    'experinceInYears':'',
    'proficiency':''
  };

  validationMessages={
    'fullName':{
      'required':'Full name is Required',
      'minlength':'Full name must be greater than 2 characters',
      'maxlenght': 'Full name must be less than 10 characters'
    },
    'email':{
      'required':'Email is Required',
      'emailDomain':'Email must be as gmail.com'
    },    
    'phone':{
      'required':'Email is Required'
    },
    'skillName':{
      'required':'Skill Name is Required'
    },
    'experinceInYears':{
      'required':'Experince In Years is Required'
    },
    'proficiency':{
      'required':'Proficiency is Required'
    }
  };



  //custom validator
  emailDomain(validationValue:string){
    return (control:AbstractControl): { [ key : string ] : any } | null => {
    const email:string=control.value;
    const domain=email.substring(email.indexOf('@')+1);
    if(email==='' || domain.toLowerCase() === validationValue.toLowerCase()){
      return null;
    }else{
      return { 'emailDomain' :true };
    }
  }
}

}
