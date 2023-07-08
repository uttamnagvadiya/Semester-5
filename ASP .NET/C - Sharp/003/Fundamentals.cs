using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    class Candidate
    {
        long candidate_id;
        double weight, height;
        int age;
        String candidate_name;
        public void getCandidateDetails()
        {
            Console.Write("Enter the Candidate ID : ");
            candidate_id = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter the Candidate Name : ");
            candidate_name = Console.ReadLine();
            Console.Write("Enter the Candidate Age : ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Candidate Weight : ");
            weight = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the Candidate Height : ");
            height = Convert.ToDouble(Console.ReadLine());
        }

        public void displayCandidateDetails()
        {
            Console.WriteLine("Candidate ID : " + candidate_id);
            Console.WriteLine("Candidate Name : " + candidate_name);
            Console.WriteLine("Candidate Age : " + age);
            Console.WriteLine("Candidate Weight : " + weight);
            Console.WriteLine("Candidate Height : " + height);
        }
    }
    class Bank_Account
    {
        long account_no;
        String user_name, email_address, account_type;
        double balance;

        public void getAccountDetails()
        {
            Console.Write("Enter the Account number : ");
            account_no = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter the User name : ");
            user_name = Console.ReadLine();
            Console.Write("Enter the Email Address : ");
            email_address = Console.ReadLine();
            Console.Write("Enter the Account type : ");
            account_type = Console.ReadLine();
            Console.Write("Enter the Balance : ");
            balance = Convert.ToDouble(Console.ReadLine());
        }

        public void displayAccountDetails()
        {
            Console.WriteLine("Account No. : " + account_no);
            Console.WriteLine("User name : " + user_name);
            Console.WriteLine("Email Address : " + email_address);
            Console.WriteLine("Account Type : " + account_type);
            Console.WriteLine("Balance : " + balance);
        }
    }
    class Student
    {
        long enrollment_no;
        int sem;
        double spi, cpi;
        String name;

        public Student(long enrollment_no, int sem, double spi, double cpi, String name)
        {
            this.enrollment_no = enrollment_no;
            this.sem = sem;
            this.spi = spi;
            this.cpi = cpi;
            this.name = name;
        }

        public void displayStudentDetails()
        {
            Console.WriteLine("Enrollment No. = "+enrollment_no);
            Console.WriteLine("Student Name = "+name);
            Console.WriteLine("Semester = "+sem);
            Console.WriteLine("SPI = "+spi);
            Console.WriteLine("CPI = "+cpi);
        }
    }
    class Salary
    {
        static double da = 0.5, hra = 0.85;
        double basic, ta;

        public Salary(double basic, double ta)
        {
            this.basic = basic;
            this.ta = ta;
        }

        public void displaySalary()
        {
            Console.WriteLine($"Salary = {basic + ta + da + hra}");
        }
    }
    class Distance
    {
        double distance1, distance2, distance3;
        public Distance(double dist1, double dist2)
        {
            this.distance1 = dist1;
            this.distance2 = dist2;

            this.distance3 = this.distance1 - this.distance2;

            Console.WriteLine($"Total distance = {this.distance3}");
        }
    }
    class Furniture
    {
        public String material = "Playwood";
        public double price = 25456.78;
    }
    class Table : Furniture
    {
        double height = 25;
        double surface_area = 235.12;
    }
}
