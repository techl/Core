# Techl.Winforms.ControlBindingHelper

Binding을 쉽게 하도록 지원

## TextBox Binding

Parameters
1. TextBox Property Name
2. Binding Target Object
3. Binding Target Object's property name
```csharp
SimpleBindingComboBoxValueTextBox.AddDataBinding(nameof(TextBox.Text), this, nameof(Grade));
```

## ComboBox Binding

### 1. 문자열 목록 바인딩

Parameters
1. ComboBox Items List
2. Binding Target Object
3. Binding Target Object's property name

```csharp
SimpleBindingComboBox.AddDataBinding(new string[] { "A", "B", "C" }, this, nameof(Grade));
```

### 2. Enum Binding

Enum에 Description이 있을 경우 Description을 보여줌.

Parameters
1. 바인딩할 대상 객체
2. 바인딩할 대상 객체의 Property Name

```csharp
EnumBindingComboBox.AddDataBinding<Status>(this, nameof(Status));

...

    public enum Status
    {
        Normal,
        Warning,
        [Description("Alarm Status")]
        Alarm
    }
```

### 3. Object Binding

Parameters
1. Object List
2. Object's Display property name
3. Object's Value property name
4. 바인딩할 대상 객체
5. 바인딩할 대상 객체의 Property Name

```csharp
var members = new Member[] {
    new Member() { ID = 1, Name = "Bud" },
    new Member() { ID = 2, Name = "Poppy" }
};

CurrentMember = members.First();

ObjectBindingComboBox.AddDataBinding(members, nameof(Member.Name), this, nameof(CurrentMember));
```