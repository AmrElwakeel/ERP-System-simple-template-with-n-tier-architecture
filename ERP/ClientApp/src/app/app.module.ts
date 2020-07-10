import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountLayoutComponent } from './Account/account-layout/account-layout.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';
import { ErpLayoutComponent } from './Erp/erp-layout/erp-layout.component';
import { IndexComponent } from './Erp/index/index.component';
import { NotfoundComponent } from './Erp/notfound/notfound.component';
import { DepartmentComponent } from './erp/department/department.component';

@NgModule({
  declarations: [
    AppComponent,
    AccountLayoutComponent,
    LoginComponent,
    RegisterComponent,
    ErpLayoutComponent,
    IndexComponent,
    NotfoundComponent,
    DepartmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
