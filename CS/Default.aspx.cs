using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Utils;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            (ASPxCardView1.CardLayoutProperties.Items[0] as CardViewCommandLayoutItem).CustomButtons.Add(CreateCustomButton());
        }
    }

    CardViewCustomCommandButton CreateCustomButton()
    {
        CardViewCustomCommandButton customBtn = new CardViewCustomCommandButton();
        customBtn.ID = "CustomBtn";
        customBtn.Text = "Custom button";
        return customBtn;
    }

    protected void ASPxCardView1_CommandButtonInitialize(object sender, ASPxCardViewCommandButtonEventArgs e)
    {
        if (e.VisibleIndex == -1) return;

        switch (e.ButtonType)
        {
            case CardViewCommandButtonType.Edit:
                e.Visible = EditButtonVisibleCriteria((ASPxCardView)sender, e.VisibleIndex);
                break;
            case CardViewCommandButtonType.Delete:
                e.Visible = DeleteButtonVisibleCriteria((ASPxCardView)sender, e.VisibleIndex);
                break;
        }
    }
    private bool EditButtonVisibleCriteria(ASPxCardView grid, int visibleIndex)
    {
        object card = grid.GetDataRow(visibleIndex);
        return ((DataRow)card)["ProductName"].ToString().Contains("a");
    }
    private bool DeleteButtonVisibleCriteria(ASPxCardView grid, int visibleIndex)
    {
        object card = grid.GetDataRow(visibleIndex);
        return ((DataRow)card)["ProductName"].ToString().Contains("b");
    }
    protected void ASPxCardView1_CustomButtonInitialize(object sender, ASPxCardViewCustomCommandButtonEventArgs e)
    {
        if (e.VisibleIndex == -1) return;

        if (e.ButtonID == "CustomBtn" && e.VisibleIndex % 2 != 0)
            e.Visible = DefaultBoolean.False;
    }
}