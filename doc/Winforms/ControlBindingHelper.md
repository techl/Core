# Techl.Winforms.ControlBindingHelper

Binding�� ���� �ϵ��� ����

## TextBox Binding

Parameters
1. TextBox Property Name
2. Binding Target Object
3. Binding Target Object's property name
```csharp
SimpleBindingComboBoxValueTextBox.AddDataBinding(nameof(TextBox.Text), this, nameof(Grade));
```

## ComboBox Binding

### 1. ���ڿ� ��� ���ε�

Parameters
1. ComboBox Items List
2. Binding Target Object
3. Binding Target Object's property name

```csharp
SimpleBindingComboBox.AddDataBinding(new string[] { "A", "B", "C" }, this, nameof(Grade));
```

### 2. Enum Binding

Enum�� Description�� ���� ��� Description�� ������.

Parameters
1. ���ε��� ��� ��ü
2. ���ε��� ��� ��ü�� Property Name

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
4. ���ε��� ��� ��ü
5. ���ε��� ��� ��ü�� Property Name

```csharp
var members = new Member[] {
    new Member() { ID = 1, Name = "Bud" },
    new Member() { ID = 2, Name = "Poppy" }
};

CurrentMember = members.First();

ObjectBindingComboBox.AddDataBinding(members, nameof(Member.Name), this, nameof(CurrentMember));
```