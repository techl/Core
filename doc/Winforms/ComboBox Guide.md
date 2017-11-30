# ComboBox Guide

Techl.Winforms.**ControlBindingHelper**를 사용하여 바인딩하여 사용한다.

## 주의사항

- 목록을 수정하지 않을 경우 ComboBox.DropDownStyle을 DropDownList로 변경한다.

- SelectedValue는 DataSource및 ValueMember에 의해 값을 가져오기 때문에 DataSource를 사용하지 않는 경우 이 값은 null이다.
 
- SelectedItem은 SelectedValue와 달리 Binding시 Focus를 잃을 때 업데이트된다. ComboBox 선택 변경시 바로 반영하려면 별도로 SelectionChangeCommitted이벤트를 받아서 처리해야 한다.

