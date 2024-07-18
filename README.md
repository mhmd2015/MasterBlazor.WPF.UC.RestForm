# MasterBlazor.WPF.UC.RestForm

This WPF library will include a variety of WPF custom controlls that provides helpful controls to WPF App

## Installation and Usage

To use the `ComboSettings1` component in another XAML page, follow these steps:

1. **Reference the Project**: If the XAML page is in a different project, you need to add a reference to the `MasterBlazor.WPF.UC.RestForm` project. In Visual Studio, you can do this by right-clicking on the `References` node in the Solution Explorer and choosing `Add Reference`. Then, select the `MasterBlazor.WPF.UC.RestForm` project.

2. **Add Namespace**: In the XAML page where you want to use the component, you need to add a namespace for the `MasterBlazor.WPF.UC.RestForm` project. At the top of your XAML file, add the following line:

    ```xml
    xmlns:restForm="clr-namespace:MasterBlazor.WPF.UC.RestForm;assembly=MasterBlazor.WPF.UC.RestForm"
    ```

    Replace `MasterBlazor.WPF.UC.RestForm` with the actual namespace and assembly name of your project.

3. **Use the Component**: Now, you can use the `ComboSettings1` component in your XAML page like this:

    ```xml
    <restForm:ComboSettings1 x:Name="comboSettings1" ComboBoxItemSelected="comboSettings1_ComboBoxItemSelected" />
    ```

4. **Code behind**: in the C# code page of xaml that you added the namespace can handle the event when change the combo box:
``` csharp
private void comboSettings1_ComboBoxItemSelected(object sender, ComboBoxItemData e)
{
    //do something after changing the dropdown selection
}
```
Remember to build your project after making these changes to ensure everything is working correctly.

## License

This project is licensed under the [MIT License](LICENSE).