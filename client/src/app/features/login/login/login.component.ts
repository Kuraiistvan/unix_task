import { Component } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login-item',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})

export class LoginComponent {
  username = '';
  password = '';
  error = '';

  constructor(private auth: AuthService) {}

  login() {
    this.auth.login({ username: this.username, password: this.password }).subscribe({
      next: () => { this.error = ''; alert('Login successful!'); },
      error: () => { this.error = 'Login failed!'; }
    });
  }
}
