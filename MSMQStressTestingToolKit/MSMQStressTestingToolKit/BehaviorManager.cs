using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * 
1.Btn Managing is being nonsense and useless , try figure out why it is not as lonely and indepence as i thought.
2.btn controlling and behavior is not that efficient like putting on main form.
3.i was like moduling coding is better for code depence but the only reason for me to do is rather than to connect all .lib or .cs.

 */


namespace MSMQStressTestingToolKit
{
    public class BehaviorManager
    {
        #region Fields
        public Dictionary<string, BtnUnit> DictBtnUnit { get; set; }
        
        #endregion

        #region Construct'n Initialize
        public BehaviorManager(Form F)
        {
            /* new BM => Get All Btns () => Transfer Into Dict () */

            DictBtnUnit = new Dictionary<string, BtnUnit>();
            var tmp = this.GetAllBtnIntoList(F);
            TurnBtnListIntoBtnDict(tmp);
        }
        #endregion

        #region Input Method
        public void AddInit(Button btn)
        {
            try
            {
                BtnUnit btnC = new BtnUnit(btn.Name, false, false, btn);
                DictBtnUnit.Add(btn.Name, btnC);
            }
            catch (Exception exc)
            {
                //TODO : REPORT MOD => LOG & DISPLAY
            }

        }
        public void AddInit(List<Button> ls)
        {
            try
            {
                ls.ForEach(b =>
                {
                    BtnUnit btnC = new BtnUnit(b.Name, false, false, b);
                    DictBtnUnit.Add(b.Name, btnC);
                });
            }
            catch (Exception exc)
            {
                //TODO : REPORT MOD => LOG & DISPLAY
            }
            
        }

        public void TurnBtnListIntoBtnDict(List<Button> ls)
        {
            AddInit(ls);
        }

        #endregion

        #region Output Method
        public int Count()
        {
            return DictBtnUnit.Count;
        }
        public Button GetBtn(string btnName)
        {
            DictBtnUnit.TryGetValue(btnName, out var temp);
            return temp.Btn;
        }
        public BtnUnit GetBtnCollections(string btnName)
        {
            DictBtnUnit.TryGetValue(btnName, out var temp);
            return temp;
        }
        public List<Button> GetAllBtnIntoList(Form F)
        {
            List<Button> tmpList = new List<Button>();
            foreach (Control ctrl in F.Controls)
            {
                if (ctrl is Button)
                {
                    tmpList.Add((Button)ctrl);
                }
            }
            return tmpList;
        }
        
        #endregion
    }

    public class BtnUnit
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Flag { get; set; }
        public Button Btn { get; set; }

        public BtnUnit(string name,bool active,bool flag,Button btn)
        {
            Name = name;
            Active = active;
            Flag = flag;
            Btn = btn;

        }
        public bool FlagReverse()
        {
            try
            {
                if (this.Flag == true)
                {
                    this.Flag = false;
                    return this.Flag;
                }
                else
                {
                    this.Flag = true;
                    return this.Flag;
                }
            }
            catch (Exception exc)
            {
                //TODO :REPORT MOD => LOG & DISPLAY
                return false;
            }
        }
        public bool NegativeBtnOff()
        {
            this.Active = false;
            this.Btn.Enabled = false;
            return false;
        }
        public bool PositiveBtnOn()
        {
            this.Active = true;
            this.Btn.Enabled = true;
            return true;
        }
        public void ButtonInit()
        {

        }
        public void Negative()
        {
            this.Active = false;
        }
        public void Positive()
        {
            this.Active = true;
        }
        public void BtnOn()
        {
            this.Btn.Enabled = true;
        }
        public void BtnOff()
        {
            this.Btn.Enabled = false;
        }
    }
}
