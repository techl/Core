using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Techl.ComponentModel;
using Techl.Winforms;

namespace Techl.TestForm
{
    public partial class ControlBindingHelperTestForm : Form, INotifyPropertyChanged
    {
        private Status status = Status.Normal;
        public Status Status
        {
            get
            {
                return status;
            }
            set
            {
                this.SetField(ref status, value);
            }
        }

        private Member currentMember;
        public Member CurrentMember
        {
            get { return currentMember; }
            set { this.SetField(ref currentMember, value); }
        }

        private int id;
        public int ID
        {
            get { return id; }
            set { this.SetField(ref id, value); }
        }

        public string Grade { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public ControlBindingHelperTestForm()
        {
            InitializeComponent();
        }

        private void ControlBindingHelperTestForm_Load(object sender, EventArgs e)
        {
            /*
             * ComboBox 사용시 주의사항
             * 
             * 내용을 목록중에서만 선택할 때는 DropDownStyle을 DropDownList로 변경한다.
             * SelectedValue는 DataSource및 ValueMember에 의해 값을 가져오기 때문에 DataSource를 사용하지 않는 경우 이 값은 null이다.
             * SelectedItem은 SelectedValue와 달리 Binding시 Focus를 잃을 때 업데이트된다. ComboBox 선택 변경시 바로 반영하려면 별도로 SelectionChangeCommitted이벤트를 받아서 처리해야 한다.
             */

            Grade = "B";
            SimpleBindingComboBox.AddDataBinding(new string[] { "A", "B", "C" }, this, nameof(Grade));
            SimpleBindingComboBoxValueTextBox.AddDataBinding(nameof(TextBox.Text), this, nameof(Grade));

            EnumBindingComboBox.AddDataBinding<Status>(this, nameof(Status));
            EnumBindingComboBoxValueTextBox.AddDataBinding(nameof(TextBox.Text), this, nameof(Status));

            var members = new Member[] {
                new Member() { ID = 1, Name = "Bud" },
                new Member() { ID = 2, Name = "Poppy" }
            };

            CurrentMember = members.First();

            ObjectBindingComboBox.AddDataBinding(members, nameof(Member.Name), this, nameof(CurrentMember));
            ObjectBindingComboBoxValueTextBox.AddDataBinding(nameof(TextBox.Text), this, nameof(CurrentMember) + "." + nameof(Member.Name));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public enum Status
    {
        Normal,
        Warning,
        [Description("Alarm Status")]
        Alarm
    }

    public class Member : BaseViewModel
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { this.SetField(ref id, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { this.SetField(ref name, value); }
        }
    }
}
