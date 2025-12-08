#include <iostream>
#include <iomanip>

using namespace std;

/* Problem1: 1. Use a two-dimensional array to solve the following problem. A company
has four salespeople (1 to 4) who sell five different products (1 to 5). Once
a day, each salesperson passes in a slip for each different type of product
sold. Each slip contains:
a. The salesperson number
b. The product number
c. The total dollar value of that product sold that day
Thus, each salesperson passes in between 0 and 5 sales slips per day. 
Assume that the information from all of the slips for last month is available. 
Write a program that will read all this information for last month’s sales 
and summarize the total sales by salesperson by product. All totals should 
be stored in the two-dimensional array sales. After processing all the 
information for last month, print the results in tabular format with each 
column representing a particular salesperson and each row representing a 
particular product. Cross total each row to get the total sales of each 
product for last month; cross total each column to get the total sales by 
salesperson for last month. Your tabular printout should include these cross 
totals to the right of the totaled rows and to the bottom of the totaled 
columns.*/
int main(){
    float sales[5][4] = {0}; // 5 products, 4 salespersons
    float salesperson[4] = {0}, products[5] = {0};
    float sum = 0, total_sales = 0;
    for(int i = 0; i < 5; i++){
        for(int j = 0; j < 4; j++){
            cout << "Enter sales amount for Product " << (i+1) << " by Salesperson " << (j+1) << ": ";
            cin >> sales[i][j];
            sum += sales[i][j];
            total_sales += sales[i][j];
        }
        products[i] = sum;
        sum = 0;
    }

    for(int j = 0; j < 4; j++){
        for(int i = 0; i < 5; i++){
            sum += sales[i][j];
        }
        salesperson[j] = sum;
        sum = 0;
    }

    // Column headers
    cout << left << setw(10) << "Product/Salesperson"
    << right << setw(5) << "SP1" << right << setw(15) << "SP2"
    << right << setw(15) << "SP3" << right << setw(15) << "SP4" 
    << right << setw(15) << "Total Product"<< '\n';
    // Separate line
    cout << setfill('-') << setw(80) << "" << setfill(' ') << '\n';
    
    for(int i = 0; i <= 5; i++){
        if(i == 5){
            cout << left << setw(10) << "Salesperson Total";
        }
        else{
            cout << left << setw(10) << "Product " + to_string(i+1);
        }
        for(int j = 0; j < 4; j++){
            if(i == 5){
                cout << right << setw(15) << fixed << setprecision(2) << salesperson[j];
            }
            else{
                cout << right << setw(15) << fixed << setprecision(2) << sales[i][j];
            }
        }
        if(i == 5){
            cout << right << setw(15) << fixed << setprecision(2) << total_sales << '\n';
        }
        else{
        cout << right << setw(15) << fixed << setprecision(2) << products[i] << '\n';
        }
    }
    return 0;
}