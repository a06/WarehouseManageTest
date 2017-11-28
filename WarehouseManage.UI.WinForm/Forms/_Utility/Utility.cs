using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.RegularExpressions;
using System.Windows.Forms;

using WarehouseManage.UI.WinForm.Properties;

namespace WarehouseManage.UI.WinForm
{
    public static class Utility
    {
        //private bool IsAllNumber(string text)
        //{
        //    //Regex objNotNumberPattern = new Regex("[^0-9.-]");
        //    //Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
        //    //Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
        //    //String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
        //    //String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
        //    //Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");
        //    //return !objNotNumberPattern.IsMatch(text) && !objTwoDotPattern.IsMatch(text) && !objTwoMinusPattern.IsMatch(text) && objNumberPattern.IsMatch(text);
        //    return false;
        //}

        private static bool DoFocusFisrt(Control control, bool tabStopOnly)
        {
            return (from Control x in control.Controls
                    where (x.CanFocus && (x.TabStop & tabStopOnly))
                    orderby x.TabIndex
                    select x.Focus()).FirstOrDefault();
        }

        public static bool FocusContainer(Control ctl)
        {
            if (ctl != null)
            {
                if (ctl.HasChildren)
                {
                    var isFocused = DoFocusFisrt(ctl, true);
                    if (isFocused) return true;

                    if (ctl.ContainsFocus == false)
                    {
                         return DoFocusFisrt(ctl, false);
                    }
                }
                return ctl.Focus();
            }
            return false;
        }

        /*public static bool IsFill(Control ctl, ErrorProvider ep, ref bool isLastPass, string displayName = "")
        {
            const string notfill = "未填写";
            if (ctl is LabelTextBox)
            {
                if ((ctl as LabelTextBox).TextBoxText == string.Empty)
                {
                    ep.SetError(ctl, (displayName == string.Empty ? (ctl as LabelTextBox).LabelText : displayName) + notfill);
                    if (isLastPass == true)
                    {
                        ctl.Focus();
                        isLastPass = false;
                    }
                }
            }
            else if (ctl is LabelSelectBox)
            {
                if ((ctl as LabelSelectBox).TextBoxText == string.Empty)
                {
                    ep.SetError(ctl, (displayName == string.Empty ? (ctl as LabelSelectBox).LabelText : displayName) + notfill);
                    if (isLastPass == true)
                    {
                        ctl.Focus();
                        isLastPass = false;
                    }
                }
            }
            return isLastPass;
        }*/

        public static void ChangeMenuItem(bool toState, ToolStripItemCollection menuItems, ToolStripItemCollection exclusionMenuItems)
        {
            foreach (ToolStripItem i in menuItems)
            {
                if (i is ToolStripMenuItem)
                {
                    var mi = (ToolStripMenuItem)i;
                    if (mi.HasDropDownItems)
                    {
                        ChangeMenuItem(toState, mi.DropDownItems, exclusionMenuItems);
                    }
                    else
                    {
                        if (exclusionMenuItems != null && exclusionMenuItems.Contains(mi))
                        {
                            mi.Enabled = !toState;
                        }
                        else
                        {
                            mi.Enabled = toState;
                        }
                    }
                }
            }
        }

        public static void ShowInfo(string text, IWin32Window owner = null)
        {
            MessageBox.Show(owner, text, Resources.MessageCaption_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string text, IWin32Window owner = null)
        {
            MessageBox.Show(owner, text, Resources.MessageCaption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowQuestionYesNo(string text, string caption = "", IWin32Window owner = null)
        {
            return MessageBox.Show(owner, text, (caption == string.Empty) ? Resources.MessageCaption_Question : caption,
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2);
        }

        public static DialogResult ShowQuestionYesNoCancel(string text, string caption = "", IWin32Window owner = null)
        {
            return MessageBox.Show(owner, text, (caption == string.Empty) ? Resources.MessageCaption_Question : caption,
                                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button3);
        }
    }

    /// <summary>
    /// 列表/编辑窗口状态
    /// </summary>
    [Flags]
    public enum TabActiveState
    {
        BrowseTabActived = 1,
        EditTabActived = 2,
        MoreTabActived = 4,
    }

    /// <summary>
    /// 窗口状态
    /// </summary>
    public enum FormState
    {
        Browse,
        Edit,
        Extend,
    }

    /// <summary>
    /// 列表状态
    /// </summary>
    [Flags]
    public enum BrowseState
    {
        Detached = 1,
        CanAddItem = 2,
        CanEditItem = 4,
        CanDeleItem = 8,
        CanViewItem = 16,
        CanExport = 32,
    }

    /// <summary>
    /// 列表状态
    /// </summary>
    [Flags]
    public enum ReportState
    {
        Detached = 1,
        CanAddItem = 2,
        CanEditItem = 4,
        CanDeleItem = 8,
        CanViewItem = 16,
        CanExport = 32,
    }

    /// <summary>
    /// 编辑状态
    /// </summary>
    [Flags]
    public enum EditState
    {
        //     The row has been created but is not part of any System.Data.DataRowCollection.
        //     A System.Data.DataRow is in this state immediately after it has been created
        //     and before it is added to a collection, or if it has been removed from a
        //     collection.
        Detached = 1,
        //     The row has not changed since System.Data.DataRow.AcceptChanges() was last
        //     called.
        Unchanged = 2,
        //     The row has been added to a System.Data.DataRowCollection, and System.Data.DataRow.AcceptChanges()
        //     has not been called.
        Created = 4,
        //     The row was deleted using the System.Data.DataRow.Delete() method of the
        //     System.Data.DataRow.
        Deleted = 8,
        //     The row has been modified and System.Data.DataRow.AcceptChanges() has not
        //     been called.
        Modified = 16,

        ReadOnly = 32,
    }

}
