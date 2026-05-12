import { Component, input, output } from '@angular/core';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-product-filter',
  imports: [CurrencyPipe],
  templateUrl: './product-filter.html',
  styleUrl: './product-filter.css',
})
export class ProductFilter {
  // Inputs received from the parent component
  categories = input.required<string[]>();
  totalPrice = input.required<number>();

  // Output event to send the selected category back to the parent component
  categoryChanged = output<string>();

  // Function triggered when the user changes the dropdown selection
  onSelectCategory(event: Event){
    const selectElement = event.target as HTMLSelectElement;
    this.categoryChanged.emit(selectElement.value);
  }

}
