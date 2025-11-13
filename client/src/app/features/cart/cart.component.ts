import { Component, inject } from '@angular/core';
import { CartService } from '../../core/services/cart.service';
import { CatItemComponent } from './cat-item/cat-item.component';
import { OrderSummaryComponent } from "../../shared/components/order-summary/order-summary.component";

@Component({
  selector: 'app-cart',
  imports: [CatItemComponent, OrderSummaryComponent],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.scss',
})
export class CartComponent {
  cartService = inject(CartService);
}
