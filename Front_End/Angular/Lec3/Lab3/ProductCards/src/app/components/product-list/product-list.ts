import { Component, computed, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductFilter } from '../product-filter/product-filter';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-product-list',
  imports: [CommonModule, ProductFilter],
  templateUrl: './product-list.html',
  styleUrl: './product-list.css',
})
export class ProductList {
  // 1. The main array of products
  products  = signal<Product[]>([
    {
      id: 1, name: 'Gaming Laptop', price: 1200, category: 'Electronics', imageUrl:'https://th.bing.com/th/id/OIP.rCxER2lzK5NByFoe5-9MaAHaEK?w=270&h=180&c=7&r=0&o=7&pid=1.7&rm=3'
    },
    {
      id: 2, name: 'Casual T-Shirt', price: 25, category: 'Clothing', imageUrl: 'https://th.bing.com/th/id/OIP.am5fTIudOuWVjIHQGmcguAHaHa?w=195&h=195&c=7&r=0&o=7&pid=1.7&rm=3' 
    },
    {
      id: 3, name: 'Gold Ring', price: 500, category: 'Jewelery', imageUrl: 'https://th.bing.com/th/id/OIP.5F_VcHXK7A1UPGrhMhtj6wHaE8?w=267&h=180&c=7&r=0&o=7&pid=1.7&rm=3'
    },
    {
      id: 4, name: 'Wireless Mouse', price: 45, category: 'Electronics', imageUrl: 'https://th.bing.com/th/id/OIP.AaaQMI9tWT6HDarv9OK4fgHaHa?w=174&h=180&c=7&r=0&o=7&pid=1.7&rm=3'
    }
  ]);

  // 2. Extract unique categories from the products array to send to the child
  categoryList = computed(() => {
    const allCategories = this.products().map(p => p.category);
    return [...new Set(allCategories)];     // Remove duplicates
  })

  // 3. Signal to store the currently selected category from the child component
  selectedCategory = signal<string>('All');

  // 4. Computed signal to automatically filter products based on the selected category
  filteredProducts = computed(() => {
    const currentCategory = this.selectedCategory();
    if(currentCategory === 'All'){
      return this.products();
    }
    return this.products().filter(p => p.category === currentCategory);
  });

  // 5. Computed signal to automatically calculate the total price of the FILTERED products
  totalFilteredPrice = computed(() => {
    return this.filteredProducts().reduce((sum, product) => sum + product.price, 0);
  });

  // 6. Function to handle the event emitted from the child component
  onFilterChange(category: string){
    this.selectedCategory.set(category);
  }

}
