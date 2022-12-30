# FBootstrapCoreMvc

## Overview

This library provides easier fluent implementation of Bootstrap UI (v5.2) library. (development still ongoing)

## Example Usages

```
@Html.Bootstrap().Heading1("Form")
using (var form = Html.Bootstrap().Form("Submit", "Home", FormMethod.Post).Begin())
{
	@form.InputFor(model => model.Name).SetMaxLength(50).IsRequired()
	@form.InputFor(model => model.Surname).SetMaxLength(50).IsRequired()
	@form.InputFor(model => model.Age).SetType(FormInputType.Number).IsRequired()
	@form.InputFor(model => model.Email).SetType(FormInputType.Email).IsRequired()
	@form.TextAreaFor(model => model.Bio).SetMaxLength(200).IsRequired()
	@form.SelectFor(model => model.Gender, genderOpts)
	@form.CheckFor(model => model.Married)
	@form.PasswordFor(model => model.Password).SetMaxLength(16).IsRequired()
	@form.Submit()
}
```

```
    @Html.Bootstrap().Heading1("Pagination-Example-3")
    @using (var pagination = Html.Bootstrap().Pagination().SetSize(ComponentSize.Large).JustifyContent(JustifyContent.End).Begin())
    {
        @pagination.PageItem("1")
        @pagination.PageItem("2").SetActive()
        @pagination.PageItem("3").SetDisabled()
        @pagination.PageItem("4")
    }
```