#include <iostream>

using namespace std;


#define SUBJECTS 5
struct Student{
    int ID;
    char Name[30];
    int Grades[5];
};

Student FillStudent();
void PrintStudent(Student &student);
int SumGrades(Student &student);

int main(){
    int number = 0;
    cout << "Enter number of students: ";
    cin >> number;
    Student *arr = new Student[number];
    for(int i = 0; i < number; i++){
        arr[i] = FillStudent();
    }
    for(int i = 0; i < number; i++){
        PrintStudent(arr[i]);
        int sum = SumGrades(arr[i]);
        cout << "Sum of Grades for student " << arr[i].ID << " is: " << sum << endl;
    }
    delete(arr);
    return 0;
}

Student FillStudent(){
    Student student;
    cout << "Enter student name: ";
    cin >> student.Name;
    cout << "Enter student ID: ";
    cin >> student.ID;
    for(int i = 0; i < SUBJECTS; i++){
        cout << "Enter Grade for subject " << i+1 << ": ";
        cin >> student.Grades[i];
    }
    return student;
}

void PrintStudent(Student &student){
    cout << "Student Name is: " << student.Name << endl;
    cout << "Student ID is: " << student.ID << endl;
    cout << "Grades for the 5 subjects" << endl;
    for(int i = 0; i < SUBJECTS; i++){
        cout << "Subject " << i+1 << ": " << student.Grades[i] << endl;
    }
}

int SumGrades(Student &student){
    int sum = 0;
    for(int i = 0; i < SUBJECTS; i++){
        sum += student.Grades[i];
    }
    return sum;
}