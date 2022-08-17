import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoandetailsComponent } from './loandetails/loandetails.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'loandetail',
    pathMatch: 'full'
  },
  {
    path: 'loandetail',
    component: LoandetailsComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoanDetailsRoutingModule { }
