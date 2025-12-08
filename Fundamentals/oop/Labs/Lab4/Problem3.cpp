#include <iostream>

using namespace std;

/* Problem 3: A class contains 3 students each study 4 subject, it is required:
Sum of each student
Average of each subject
Student Ranked 1st in the class */
int main(){
    int students[3][4], sum_student[3], sum_subject[4];
    float avg_subject[4];
    int temp = 0;
    for(int i = 0; i < 3; i++){
        cout << "Enter marks for Student " << (i+1) << "\n";
        for(int j = 0; j < 4; j++){
            cout << " Subject " << (j+1) << ": ";
            cin >> students[i][j];
            temp += students[i][j];
        }
        sum_student[i] = temp;
        temp = 0;
        cout << "\n";
    }
    cout << "\n";
    for(int j = 0; j < 4; j++){
        for(int i = 0; i < 3; i++){
            temp += students[i][j];
        }
        sum_subject[j] = temp;
        avg_subject[j] = (float)(temp) / 3;
        temp = 0;
    }
    // Print results
    int max_student = sum_student[0];
    for(int i = 0; i < 3; i++){
        cout << "Total marks for Student " << (i+1) << ": " << sum_student[i] << "\n";
        if(sum_student[i] > max_student){
            max_student = sum_student[i];
        }
    }
    cout << "\n";

    for(int j = 0; j < 4; j++){
        // cout << "Total marks for Subject " << (j+1) << ": " << sum_subject[j] << "\n";
        cout << "Average marks for Subject " << (j+1) << ": " << avg_subject[j] << "\n";
    }
    cout << "\n";
    cout << "Highest marks obtained by a student: " << max_student << "\n";
    return 0;
}