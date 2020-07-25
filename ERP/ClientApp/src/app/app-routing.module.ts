import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AccountLayoutComponent } from './Account/account-layout/account-layout.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';
import { ErpLayoutComponent } from './Erp/erp-layout/erp-layout.component';
import { IndexComponent } from './Erp/index/index.component';
import { NotfoundComponent } from './Erp/notfound/notfound.component';
import { DepartmentComponent } from './erp/department/department.component';
import { CreatedepartmentComponent } from './erp/department/createdepartment/createdepartment.component';


const routes: Routes = [
  { path: '', redirectTo: '/index', pathMatch: 'full' },
  {
    path: '', component: ErpLayoutComponent,
    children: [
      { path: 'index', component: IndexComponent },
      {
        path: 'department', children: [
          { path: '', component: DepartmentComponent },
          { path: 'create', component: CreatedepartmentComponent }
        ]
      },
      { path: 'notfound', component: NotfoundComponent }
    ]
  },
  {
    path: 'account', component: AccountLayoutComponent,
    children: [
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  { path: '**', redirectTo: '/notfound', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
