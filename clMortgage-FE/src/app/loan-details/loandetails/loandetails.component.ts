import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { map } from 'rxjs';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-loandetails',
  templateUrl: './loandetails.component.html',
  styleUrls: ['./loandetails.component.sass']
})
export class LoandetailsComponent implements OnInit {
  authForm: UntypedFormGroup;
  submitted = false;
  returnUrl: string;
  hide = true;
  chide = true;
  loading = true;
  error = '';
  state: any;
  detailId: Guid;
  onEdit = false;
  data: any;
  constructor(
    private formBuilder: UntypedFormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {

  }

  ngOnInit(): void {
     this.detailId = this.route.snapshot.queryParams.id;
    if (this.detailId) {
      this.onEdit = true;
    }
    this.getLoanDataById(this.detailId);
    this.authForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      mobileNumber: ['', Validators.required],
      source: ['', Validators.required],
      loanPurpose: ['', Validators.required],
      salariedRecived: ['', Validators.required],
      dob: ['', Validators.required],
      workingCompany: ['', Validators.required],
      grossSalary: ['', Validators.required],
      propertyLocation: this.formBuilder.group({
        huseNo: ['', Validators.required],
        city: ['', Validators.required],
        pinNo: ['', Validators.required],
        state: ['', Validators.required],
      }),
      accountNumber: [""],
      email: [
        '',
        [Validators.required, Validators.email, Validators.minLength(5)],
      ],
    });
    this.loading =false;
  }
  get f() {
    this.authForm.contains['accountNumber'].disable();
    return this.authForm.controls;
  }
  get propertyLocation() {
    return this.authForm.get('propertyLocation') as FormGroup;
  }
  getLoanDataById(id) {
    this.loading =true;
    this.authService.GetLoanDetailsById(id).subscribe((res) => {
      this.data=res;
      if (this.data) {
          this.authForm.setValue({
            firstName: this.data?.firstName,
            lastName: this.data?.lastName,
            mobileNumber: this.data?.mobileNumber,
            source: this.data?.source,
            loanPurpose: this.data?.loanPurpose,
            salariedRecived: this.data?.salariedRecived,
            dob: this.data?.dob,
            workingCompany: this.data?.workingCompany,
            grossSalary: this.data?.grossSalary,
            propertyLocation: {
              huseNo: this.data?.propertyLocation?.huseNo,
              city: this.data?.propertyLocation?.city,
              pinNo: this.data?.propertyLocation?.pinNo,
              state: this.data?.propertyLocation?.state,
            },
            accountNumber: this.data?.accountNumber,
            email: this.data?.email,
          });
      }
    })
    this.loading =false;
  }
  onSubmit() {
    debugger;
    this.submitted = true;
    this.loading = true;
    this.error = '';
    this.submitted = true;
    // stop here if form is invalid
    if (this.authForm.invalid) {
      return;
    }
    else {
      if (this.detailId) {
        this.authService.updateLoanDetail(this.authForm.value, this.detailId, this.data.propertyLocationid).subscribe((res) => {
          let result = res;
          this.router.navigate(['/admin/dashboard/main']);
        })
      } else {
        this.authService.AddLoanAccount(this.authForm.value).subscribe((res) => {
          let result = res;
          this.router.navigate(['/admin/dashboard/main']);
        })
      }
    }
  }
}

