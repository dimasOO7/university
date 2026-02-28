namespace app2
{
    class Student
    {
        public string FIO { get; set; }
        private byte[] marks;
        public byte[] Marks
        {
            get
            {
                return marks;
            }
            set
            {
                marks = value;
            }
        }

        public Student(string fio, byte[] marks)
        {
            FIO = fio;
            this.marks = marks;
        }
    }

    class Group
    {
        public string GroupId { get; set; }
        private Student[] students;

        public Student[] Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
            }
        }

        private string[] subjects;
        public string[] Subjects
        {
            get
            {
                return subjects;
            }
            set
            {
                subjects = value;
            }
        }

        public Group(string groupId, string[] subjects)
        {
            GroupId = groupId;
            Subjects = subjects;
            Students = new Student[3];
        }
    }
    class Cource
    {
        public string CourceId { get; set; }
        private Group[] groups;

        public Group[] Groups
        {
            get
            {
                return groups;
            }
            set
            {
                groups = value;
            }
        }

        public Cource(string courceId)
        {
            CourceId = courceId;
            Groups = new Group[2];
        }

        public void ShowBad()
        {
            foreach(Group group in Groups)
            {
                foreach(Student student in group.Students)
                {
                    string dvoyki = "";
                    for (int i = 0; i < student.Marks.Length; i++)
                    {
                        if (student.Marks[i] == 2)
                        {
                            dvoyki += " ";
                            dvoyki += group.Subjects[i];
                        }
                    }
                    if(dvoyki != "")
                    {
                        Console.WriteLine($"{student.FIO}, группа: {group.GroupId}, 2 по:{dvoyki}");
                    }
                }
            }
        }

        static void Main()
        {
            Student st1 = new Student("Ivanov", new byte[] { 2, 3, 4, 5, 2 });
            Student st2 = new Student("Petrov", new byte[] { 5, 3, 4, 5, 3 });
            Student st3 = new Student("Sidorov", new byte[] { 3, 3, 4, 2, 5 });
            Student st4 = new Student("Antonov", new byte[] { 3, 3, 3, 3, 3 });
            Student st5 = new Student("Borodin", new byte[] { 5, 3, 4, 5, 3 });
            Student st6 = new Student("Tarasov", new byte[] { 3, 2, 4, 2, 5 });

            Group gr1 = new Group("6101", new string[] { "mat", "fiz", "hist", "progr", "eng" });
            gr1.Students[0] = st1;
            gr1.Students[1] = st2;
            gr1.Students[2] = st3;

            Group gr2 = new Group("6109", new string[] { "diskr_mat", "fiz", "algebra", "progr", "eng" });
            gr2.Students[0] = st4;
            gr2.Students[1] = st5;
            gr2.Students[2] = st6;

            Cource cr = new Cource("Cource 1");
            cr.Groups[0] = gr1;
            cr.Groups[1] = gr2;
            cr.ShowBad();
        }
    }
}