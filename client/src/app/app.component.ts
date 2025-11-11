import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { Product } from './shared/models/Product';
import { Pagination } from './shared/models/Pagination';
import { ShopService } from './core/services/shop.service';
import { ShopComponent } from "./features/shop/shop.component";

@Component({
  selector: 'app-root',
  standalone : true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent implements OnInit{
  title = "Unix_App";

  ngOnInit(): void {
    
  }
}
