#include <iostream>
#include <ctype.h>

using namespace std;

#define COMMANDS 50

void Print2DArray(char board[50][50], int row, int col){
    for(int i = 0; i < row; i++){
        for(int j = 0; j < col; j++){
            cout << board[i][j];
        }
        cout << endl;
    }
}

int main(){
    char board[50][50]; // 50 rows and 50 columns
    char commands[COMMANDS] = {0}; // 20 steps
    cout << "Enter the steps until 20 steps (spaces allowed): " << endl;
    // Read the turtle movement from the user
    cin.getline(commands, COMMANDS);

    // Define variables and flags
    int x = 0, y = 0;       // Current position
    int direction = 0;      // 0 = right, 1 = down, 2 = left, 3=up
    int write = 0;          // Flag to write on the board (0 => ' , 1 => '*')
    int max_x_drawn = 0;    // Maximum x drawn
    int max_y_drawn = 0;    // Maximum y drawn
    int steps = 0;          // Number of steps the turtle will walk

    // Initialize the board with spaces
    for(int i = 0; i < 50; i++){
        for(int j = 0; j < 50; j++){
            board[i][j] = ' ';
        }
    }

    // Execute the commands
    for(int i = 0; i < COMMANDS && commands[i] != '\0'; i++){
        if(commands[i] == ' '){
            continue;
        }
        else if(commands[i] == '5'){
            i += 2;     // skip the comma ','
            // Get number of steps
            if(isdigit(commands[i+1])) {
                steps = (commands[i] - '0') * 10 + (commands[i+1] - '0');
                i++;
            } else {
                steps = commands[i] - '0';
            }
            // Move based on current direction
            for(int j = 0; j < steps; j++){ // تغيير الشرط إلى <= بدلاً من <
                if(write == 1) { // If pen is down, draw '*'
                    board[y][x] = '*';
                    if(x > max_x_drawn){max_x_drawn = x;}
                    if(y > max_y_drawn){max_y_drawn = y;}
                }
                if(j < steps - 1) { // نتحرك فقط إذا لم نصل للخطوة الأخيرة
                    switch(direction) {
                        case 0: // Moving right
                            if(x < 49) x++;
                            break;
                        case 1: // Moving down
                            if(y < 49) y++;
                            break;
                        case 2: // Moving left
                            if(x > 0) x--;
                            break;
                        case 3: // Moving up
                            if(y > 0) y--;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        else if(commands[i] == '1'){
            write = 0;  // Pen up
        }
        else if(commands[i] == '2'){
            write = 1;  // Pen down
        }
        else if(commands[i] == '3'){
            direction = (direction + 1) % 4;  // Turn right (0->1->2->3->0)
        }
        else if(commands[i] == '6'){
            Print2DArray(board, max_y_drawn + 1 , max_x_drawn + 1);
            break;
        }
    }
    return 0;
}