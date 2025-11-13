import { Component, inject, signal } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { MatAnchor } from '@angular/material/button';
import { environment } from '../../../../environments/environment.development';
import { CartService } from '../../../core/services/cart.service';

@Component({
  selector: 'app-order-form',
  standalone: true,
  imports: [ReactiveFormsModule, MatAnchor],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.scss'
})
export class OrdersComponent {
  baseUrl = environment.apiUrl;
  cartService = inject(CartService);
  orderForm: FormGroup;
  submitted = signal(false);
  successMessage = signal('');
  errorMessage = signal('');

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.orderForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required],
      phone: ['', [Validators.required, Validators.pattern(/^\+?\d{7,15}$/)]],
    });
  }

submitOrder() {
  this.submitted.set(true);
  if (this.orderForm.invalid) return;

  const orderData = {
    name: this.orderForm.value.name,
    email: this.orderForm.value.email,
    address: this.orderForm.value.address,
    phone: this.orderForm.value.phone,
    items: this.cartService.cart()?.items
  };

  this.http.post(this.baseUrl + 'orders', orderData).subscribe({
    next: res => {
      alert('Order submitted!');
      this.orderForm.reset();
      this.submitted.set(false);
    },
    error: err => {
      console.error(err);
      alert('Failed to submit order.');
    }
  });
}

}
