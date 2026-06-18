namespace Ex10_MVC
{
    // The Controller Class
    public class StudentController
    {
        private Student _model;
        private StudentView _view;

        public StudentController(Student model, StudentView view)
        {
            _model = model;
            _view = view;
        }

        public void SetStudentName(string name)
        {
            _model.Name = name;
        }

        public string GetStudentName()
        {
            return _model.Name;
        }

        public void SetStudentRollNo(string rollNo)
        {
            _model.RollNo = rollNo;
        }

        public string GetStudentRollNo()
        {
            return _model.RollNo;
        }

        public void UpdateView()
        {
            _view.PrintStudentDetails(_model.Name, _model.RollNo);
        }
    }
}
