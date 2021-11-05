import { OnDestroy } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ConstantsService } from '../../../../CommonServices/constants.service';
import { DialogHandlerService } from '../../../../CommonServices/DialogHandler/dialog-handler.service';
import { TranslationService } from '../../../../CommonServices/translation-service.service';
import { EmailConfirmationModel } from '../../../Models/email-confirmation-model.model';
import { ClientAccountService } from '../../Authentication/client-account-service.service';

@Component({
  selector: 'app-email-confirmation-client',
  templateUrl: './email-confirmation-client.component.html',
  styleUrls: ['./email-confirmation-client.component.css']
})
export class EmailConfirmationClientComponent implements OnInit, OnDestroy {
  //properties
  EmailConfirmationModel: EmailConfirmationModel = new EmailConfirmationModel();
  Success: boolean = false;
  Fail: boolean = false;
  Error: any;
  selected: any;
  LangSubscibtion: Subscription = new Subscription();

  //constructor
  constructor(private route: ActivatedRoute, private router: Router, public Constants: ConstantsService,
    private accountService: ClientAccountService, public dialogHandler: DialogHandlerService,
    public translate: TranslationService) {
    this.selected = localStorage.getItem(Constants.lang);
  }
  //ngOnInit
  ngOnInit(): void {
    console.log("Called");
    this.LangSubscibtion = this.translate.SelectedLangSubject.subscribe(
      (response: any) => {
        this.selected = response;
      }
    );
    const email = this.route.snapshot.queryParamMap.get(this.Constants.email);
    const token = this.route.snapshot.queryParamMap.get(this.Constants.token);
    console.log(email);
    if (email && token) {
      this.EmailConfirmationModel = { email: email, token: token }
      console.log(this.EmailConfirmationModel);
      this.emailConfirmation(this.EmailConfirmationModel);
    } else {
      this.router.navigateByUrl("/");
    }
  }

  emailConfirmation(emailConfimationModel: EmailConfirmationModel) {
    this.accountService.confirmEmail(emailConfimationModel).subscribe(
      (Response: any) => {
        this.Success = true,
          console.log(Response)
      },
      (error: any) => { this.Fail = true; this.Error = error[0].error; console.log(error) }
    );
  }
  switchLang(lang: string) {
    this.selected = this.translate.setTranslationLang(lang);
  }

  ngOnDestroy(): void {
    this.LangSubscibtion.unsubscribe();
  }
}
