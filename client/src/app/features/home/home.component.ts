import { Component } from '@angular/core';
import { LoginComponent } from '../login/login/login.component';

@Component({
  selector: 'app-home',
  imports: [LoginComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {

}
