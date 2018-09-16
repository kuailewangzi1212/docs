using Newtonsoft.Json;
using SIS.Common;
using SIS.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;

namespace SIS.API
{
    /// <summary>
    /// GetWay 的摘要说明
    /// </summary>
    public class GetWay : IHttpHandler
    {
        public const string parameterInvalid = "输入参数无效";
        public const string ACCESS_FORBIDDEN = "ACCESS_FORBIDDEN";
        public const string PARTNER_ERROR = "PARTNER_ERROR";
        public const string key = "sxzy2008";
        public const string APP_ID = "sxzy88064518";
        public GetWay()
        {
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string argu0 = context.Request["argu0"];
            //Logger.Debug(this.GetType().ToString(), argu0);
            string msg = "";
            msg = Process(argu0);

            context.Response.Write(msg);
        }


        protected string Process(string args0)
        {
            #region 参数初审化
          
            //======================================
            string msg = string.Empty;
            string appid = string.Empty;
            string method = string.Empty;
            string sign = string.Empty;
            string timestamp = string.Empty;
            string biz_content = string.Empty;
            string sign_new = string.Empty;
            string fwzh = string.Empty;
            string sqdh = string.Empty;
            string fch = string.Empty;
            string dph = string.Empty;
            string str = string.Empty;
            string str2 = string.Empty;
            int pageSize = 10000;
            int pageIndex = 0;
           
            JavaScriptArray tmpArray = null;
            JavaScriptObject tmpObjec = null;
            List<input_sbd> inputSbdList = null;
            List<inputGzd> inputGzdList = null;
            List<inputGhfwhd> inputFwhdList = null;
            List<inputGhfwhdCx> inputFwhdCxList = null;
            List<inputWts> inputWtsList = null;
            retMsg response = new retMsg();
            #endregion

            #region 解析参数是否合法
            if (string.IsNullOrEmpty(args0) || args0.Trim() == "")
            {
                response.code = "40004";
                response.msg = parameterInvalid;
                return JavaScriptConvert.SerializeObject(response);
            }
            try
            {
                JavaScriptObject jsonObjec = (JavaScriptObject)JavaScriptConvert.DeserializeObject(args0);
                appid = jsonObjec["app_id"].ToString();
                method = jsonObjec["method"].ToString();
                sign = jsonObjec["sign"].ToString();
                timestamp = jsonObjec["timestamp"].ToString();

                switch(method)
                {
                    case "DM_clk":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        pageSize = int.Parse(tmpObjec["pageSize"].ToString().Trim());
                        pageIndex = int.Parse(tmpObjec["pageIndex"].ToString().Trim());
                        break;
                    case "DM_fwzk":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        fch = tmpObjec["fch"].ToString().Trim();
                        break;
                    case "GetCssz":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        str = tmpObjec["bh"].ToString().Trim();
                        break;
                    case "GetClxx":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        dph = tmpObjec["dph"].ToString().Trim();
                        break;
                    case "GetClxx2":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        dph = tmpObjec["dph"].ToString().Trim();
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        fch = tmpObjec["fch"].ToString().Trim();
                        break;
                    case "getClxxByDealer":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        fch = tmpObjec["fch"].ToString().Trim();
                        str = tmpObjec["lzrq1"].ToString().Trim();
                        str2 = tmpObjec["lzrq2"].ToString().Trim();
                        break;
                    case "GetSbd":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        sqdh = tmpObjec["sqdh"].ToString().Trim();
                        break;
                    case "GetSbdWxsqdh":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        sqdh = tmpObjec["wxsqdh"].ToString().Trim();
                        fch = tmpObjec["fch"].ToString().Trim();
                        break;
                    case "GetSpd":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        sqdh = tmpObjec["sqdh"].ToString().Trim();
                        break;
                    case "GetSpdWxsqdh":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        sqdh = tmpObjec["wxsqdh"].ToString().Trim();
                        fch = tmpObjec["fch"].ToString().Trim();
                        break;
                    case "GetSbdRecords":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        dph = tmpObjec["dph"].ToString().Trim();
                        break;
                    case "GetGzdRecords":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        dph = tmpObjec["dph"].ToString().Trim();
                        break;
                    case "Zfdj": 
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        sqdh = tmpObjec["sqdh"].ToString().Trim();
                        fch = tmpObjec["fch"].ToString().Trim();
                        str = tmpObjec["type"].ToString().Trim();
                        break;
                    case "Cxdj":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        str = tmpObjec["type"].ToString().Trim();
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        fch = tmpObjec["fch"].ToString().Trim();
                        sqdh = tmpObjec["sqdh"].ToString().Trim();
                        break;
                    case "chk_fwhdTx":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        dph = tmpObjec["dph"].ToString().Trim();
                        break;
                    case "queryghcxfwhd":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        fch = tmpObjec["fch"].ToString().Trim();
                        dph = tmpObjec["dph"].ToString().Trim();
                        str = tmpObjec["hdbhs"].ToString().Trim();
                        break;
                    case "getghcxfwhd":
                        tmpObjec = jsonObjec["biz_content"] as JavaScriptObject;
                        biz_content = JavaScriptConvert.SerializeObject(tmpObjec);
                        fwzh = tmpObjec["fwzh"].ToString().Trim();
                        fch = tmpObjec["fch"].ToString().Trim();
                        dph = tmpObjec["dph"].ToString().Trim();
                        break;
                    case "importghcxfwhd":
                        tmpArray = jsonObjec["biz_content"] as JavaScriptArray;
                        //biz_content = JavaScriptConvert.SerializeObject(tmpArray);
                        //inputFwhdList = JavaScriptConvert.DeserializeObject<List<inputGhfwhd>>(biz_content);
                        inputFwhdList = getGhFwhdListFromJson(tmpArray);
                        break;
                    case "cxghcxfwhd":
                        tmpArray = jsonObjec["biz_content"] as JavaScriptArray;
                        //biz_content = JavaScriptConvert.SerializeObject(tmpArray);
                        //inputFwhdCxList = JavaScriptConvert.DeserializeObject<List<inputGhfwhdCx>>(biz_content);
                        inputFwhdCxList = getGhFwhdCxListFromJson(tmpArray);
                        break;
                    case "importbyd": 
                        tmpArray = jsonObjec["biz_content"] as JavaScriptArray;
                        //biz_content = JavaScriptConvert.SerializeObject(tmpArray);
                        //inputSbdList = JavaScriptConvert.DeserializeObject<List<input_sbd>>(biz_content);
                        inputSbdList = getSbdListFromJson(tmpArray);
                        break;
                    case "importbill": 
                        tmpArray = jsonObjec["biz_content"] as JavaScriptArray;
                        //biz_content = JavaScriptConvert.SerializeObject(tmpArray);
                        //inputGzdList = JavaScriptConvert.DeserializeObject<List<inputGzd>>(biz_content);
                        inputGzdList = getGzdListFromJson(tmpArray);
                        break;
                    case "insertWts":
                        tmpArray = jsonObjec["biz_content"] as JavaScriptArray;
                        //biz_content = JavaScriptConvert.SerializeObject(tmpArray);
                        //inputWtsList = JavaScriptConvert.DeserializeObject<List<inputWts>>(biz_content);
                        inputWtsList = getWtsListFromJson(tmpArray);
                        break;
                    default:
                        biz_content = jsonObjec["biz_content"].ToString();
                        break;
                }
            }
            catch (Exception)
            {
                response.code = "40004";
                response.msg = parameterInvalid;
                return JavaScriptConvert.SerializeObject(response);
            }
            #endregion

            #region 验证权限
            if (appid != APP_ID)
            {
                response.code = "40004";
                response.msg = PARTNER_ERROR;
                return JavaScriptConvert.SerializeObject(response);
            }
            
            sign_new = SIS.Common.MD5Encrypt.Encrypt(appid + method + timestamp + biz_content + key, 32).ToUpper();
            sign_new = "";
            sign = "";
            if (sign_new != sign.ToUpper())
            {
                response.code = "40004";
                response.msg = ACCESS_FORBIDDEN;
                return JavaScriptConvert.SerializeObject(response);
            }
            #endregion

            switch (method)
            {
                #region 更新代码库
                case "DM_xhk":
                    response.data = DM_xhk("",ref msg); break;
                case "DM_gsk":
                    response.data = DM_gsk("",ref msg); break;
                case "DM_clk":
                    response.data = DM_clk(pageSize, pageIndex, ref msg); break;
                case "DM_ssj":
                    response.data = DM_ssj("",ref msg); break;
                case "DM_ssjclk":
                    response.data = DM_ssjclk("",ref msg); break;
                case "DM_ssjgzlb":
                    response.data = DM_ssjgzlb("",ref msg); break;
                case "DM_gzlb":
                    response.data = DM_gzlb("",ref msg); break;
                case "DM_bjzzc":
                    response.data = DM_bjzzc("",ref msg); break;
                case "DM_gwcl":
                    response.data = DM_gwcl("",ref msg); break;
                case "DM_ysk":
                    response.data = DM_ysk("",ref msg); break;
                case "DM_bjcclk":
                    response.data = DM_bjcclk("",ref msg); break;
                case "DM_fwzk":
                    response.data = DM_fwzk(fwzh, fch,ref msg); break;
                case "DM_fwzkall":
                    response.data = DM_fwzkall("",ref msg); break;
                case "DM_zylb":
                    response.data = DM_zylb("",ref msg); break;
                case "DM_xllb":
                    response.data = DM_xllb("",ref msg); break;
                case "DM_wxmb":
                    response.data = DM_wxmb("",ref msg); break;
                case "DM_wxmb_cl":
                    response.data = DM_wxmb_cl("",ref msg); break;
                case "DM_wxmb_wxxm":
                    response.data = DM_wxmb_wxxm("",ref msg); break;
                case "DM_cx_gsbz":
                    response.data = DM_cx_gsbz("",ref msg); break;
                case "DM_gsk_cf":
                    response.data = DM_gsk_cf("",ref msg); break;
                case "DM_cxt":
                    response.data = DM_cxt("",ref msg); break;
                case "DM_bzk":
                    response.data = DM_bzk("",ref msg); break;
                case "DM_zfxz":
                    response.data = DM_zfxz("",ref msg); break;
                case "DM_fwztdcx":
                    response.data = DM_fwztdcx("",ref msg); break;
                case "DM_cxzsbyk":
                    response.data = DM_cxzsbyk("",ref msg); break;
                case "DM_cxsbf":
                    response.data = DM_cxsbf("",ref msg); break;
                case "DM_clxxzsbyk":
                    response.data = DM_clxxzsbyk("",ref msg); break;
                case "DM_clxxsbf":
                    response.data = DM_clxxsbf("",ref msg); break;
                case "DM_clk_thj":
                    response.data = DM_clk_thj("",ref msg); break;
                case "DM_clxx_zsbyk":
                    response.data = DM_clxx_zsbyk("",ref msg); break;
                case "DM_clxx_sbf":
                    response.data = DM_clxx_sbf("",ref msg); break;
                case "DM_cx_zsbyk":
                    response.data = DM_cx_zsbyk("",ref msg); break;
                case "DM_cx_sbf":
                    response.data = DM_cx_sbf("",ref msg); break;
                case "DM_fdjm":
                    response.data = DM_fdjm("",ref msg); break;
                case "DM_pdi_gzlx":
                    response.data = DM_pdi_gzlx("", ref msg); break;
                case "DM_pdi_gzbw":
                    response.data = DM_pdi_gzbw("", ref msg); break;
                case "DM_pdi_jcxm":
                    response.data = DM_pdi_jcxm("", ref msg); break;
                case "DM_pdi_jcxmgz":
                    response.data = DM_pdi_jcxmgz("", ref msg); break;
                #endregion
                case "GetCssz":
                    response.data = GetCssz(str, ref msg); break;
                case "GetClxx":
                    response.data = GetClxx(dph, ref msg); break;
                case "GetClxx2":
                    response.data = GetClxx2(dph, fwzh, fch, ref msg); break;
                case "getClxxByDealer":
                    response.data = getClxxByDealer(fwzh, fch, str, str2, ref msg); break;
                case "GetSbd":
                    response.data = Getsbd(fwzh, sqdh, ref msg); break;
                case "GetSbdWxsqdh":
                    response.data = GetSbd_Wxsqdh(fwzh, sqdh, fch, ref msg); break;
                case "GetSpd":
                    response.data = GetSpd(fwzh, sqdh, ref msg); break;
                case "GetSpdWxsqdh":
                    response.data = GetSpd_Wxsqdh(fwzh, sqdh, fch, ref msg); break;
                case "GetSbdRecords":
                    response.data = GetSbdRecords(fwzh, dph, ref msg); break;
                case "GetGzdRecords":
                    response.data = GetGzdRecords(fwzh, dph, ref msg); break;
                case "Zfdj":
                    msg = Zfdj(str, fwzh, fch, sqdh); break;
                case "Cxdj":
                    msg = Cxdj(str, fwzh, fch, sqdh); break;
                case "chk_fwhdTx":
                    response.data = chk_fwhdTx(dph, fwzh, ref msg); break;
                case "queryghcxfwhd":
                    response.data = queryghcxfwhd(fwzh, fch, dph, str, ref msg); break;
                case "getghcxfwhd":
                    response.data = getghcxfwhd(fwzh, fch, dph, ref msg); break;
                case "importghcxfwhd":
                    response.data = importghcxfwhd(inputFwhdList, ref msg); break;
                case "cxghcxfwhd":
                    response.data = cxghcxfwhd(inputFwhdCxList, ref msg); break;
                case "importbyd":
                    response.data = importbyd(inputSbdList, ref msg); break;
                case "importbill":
                    response.data = importbill(inputGzdList, ref msg); break;
                case "insertWts":
                    response.data = insertWts(inputWtsList, ref msg); break;
                default:
                    msg = ACCESS_FORBIDDEN;
                    break;

            }

            if (msg == "success")
            {
                response.code = "10000";
                response.msg = msg;
                if (method.Substring(0, 3) == "DM_" || method == "GetSbdRecords" || method == "GetGzdRecords") //更新代码库
                    return JavaScriptConvert.SerializeObject(response, new DataTableConverter());
                else
                    return JavaScriptConvert.SerializeObject(response);
            }
            else
            {
                response.code = "40004";
                response.msg = msg;
                return JavaScriptConvert.SerializeObject(response);
            }

        }

        #region 撤销关怀促销服务活动
       
        /// <summary>
        /// 撤销关怀促销服务活动
        /// </summary>
        public List<Dictionary<string,string>> cxghcxfwhd(List<inputGhfwhdCx> fwhdcxList, ref string Msg)
        {

            if (fwhdcxList.Count == 0)
            {
                Msg = "没有数据需要处理";
                return null;
            }

            SIS.Model.fwzk Mfwzk = new SIS.Model.fwzk();
            SIS.BLL.fwzk Tfwzk = new SIS.BLL.fwzk();

            SIS.BLL.xhk b_xhk = new SIS.BLL.xhk();
            SIS.Model.xhk Mxhk = new SIS.Model.xhk();

            SIS.BLL.fwhd Tfwhd = new SIS.BLL.fwhd();
            SIS.Model.fwhd Mfwhd = new SIS.Model.fwhd();

            SIS.BLL.fwhdnr Tfwhdnr = new SIS.BLL.fwhdnr();
            SIS.Model.fwhdnr Mfwhdnr = new SIS.Model.fwhdnr();

            SIS.BLL.clxx Tclxx = new SIS.BLL.clxx();
            SIS.Model.clxx Mclxx = new SIS.Model.clxx();

            SIS.BLL.fwhdclxx Tfwhdclxx = new SIS.BLL.fwhdclxx();
            SIS.Model.fwhdclxx Mfwhdclxx = new SIS.Model.fwhdclxx();

            DataSet sbd_ds = new DataSet();
            
            string errmsg = "$";

            string hdbh = "";
            string fwzh, wxfc, spfc, wsqfch, wtsh, vin;
            bool wsqfc_flag = false;
            string msg = "";

            List<Dictionary<string, string>> resultList = new List<Dictionary<string, string>>();
            Dictionary<string, string> resultDict = null;

            foreach (inputGhfwhdCx cxfwhd in fwhdcxList)
            {
                resultDict = new Dictionary<string, string>();
                try
                {
                    fwzh = cxfwhd.fwzh.Trim();       //服务站号
                    wxfc = cxfwhd.sjfc.Trim();       //维修分厂号
                    wtsh = cxfwhd.wtsh.Trim();       //委托书号
                    hdbh = cxfwhd.hdbh.Trim();       //活动编号
                    vin = cxfwhd.dph.Trim();         //底盘号


                    spfc = "";
                    #region 必填判断

                    //VIN码不能为空
                    if (vin == "")
                    {
                        errmsg = "VIN码不能为空";
                        resultDict.Add("hdbh", hdbh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (fwzh == "")
                    {
                        errmsg = "服务站号不能为空";
                        resultDict.Add("hdbh", hdbh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    #endregion

                    #region 服务站信息/车辆等判断
                    wsqfc_flag = false;
                    if (wxfc != "")
                    {
                        if (PageValidate.IsNumber(wxfc) == true && int.Parse(wxfc) >= GlobalConst.unAuthorizedFcStart && int.Parse(wxfc) <= GlobalConst.unAuthorizedFcEnd)
                        {
                            spfc = "";
                            wsqfc_flag = true;
                        }
                        else
                        {
                            spfc = wxfc;
                            wsqfc_flag = false;
                        }
                    }
                    //判断服务站是否存在
                    Mfwzk = Tfwzk.GetModel(fwzh, spfc);
                    if (Mfwzk == null)
                    {
                        errmsg = "服务站号在售后索赔系统中不存在";
                        resultDict.Add("hdbh", hdbh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断是否锁定
                    if (IsLocked.IsLockfwz(Mfwzk) == true)
                    {
                        errmsg = "服务站已冻结或不在合同期内";
                        resultDict.Add("hdbh", hdbh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断服务站是否开通了上传功能
                    if (Mfwzk.wxscbz.Trim() != "1")
                    {
                        errmsg = "服务站还没有开通上传功能";
                        resultDict.Add("hdbh", hdbh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断未授权网点是否允许上传单据
                    if (wsqfc_flag == true)
                    {
                        wsqfch = Mfwzk.ktwsqfch.Trim();
                        if (wsqfch.IndexOf(wxfc) < 0)
                        {
                            errmsg = "网点" + wxfc + "未授权";
                            resultDict.Add("hdbh", hdbh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }
                    #endregion

                    #region 撤销服务活动判断
                    Mfwhd = Tfwhd.GetModel(hdbh);
                    if (Mfwhd == null)
                    {
                        errmsg = "此活动不存在";
                        resultDict.Add("hdbh", hdbh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    msg = Tfwhd.cx_check_fwhd_ghcx(fwzh, vin, wtsh, Mfwhd);

                    if (msg != "")
                    {
                        if (msg == "0")
                        {
                            resultDict.Add("hdbh", hdbh);
                            resultDict.Add("errmsg", "success");
                            resultList.Add(resultDict);
                            continue;
                        }
                        else
                        {
                            errmsg = msg;
                            resultDict.Add("hdbh", hdbh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }

                    #endregion

                    if (Mfwhd.cljtbz.Trim() == "1")
                    {
                        try
                        {
                            Mfwhdnr = Tfwhdnr.GetModel(hdbh, vin);

                            Mfwhdnr.rq = "";
                            Mfwhdnr.zt = "1";

                            Mfwhdnr.sqdh = "";
                            Mfwhdnr.fc = "";
                            Mfwhdnr.xslc = 0;
                            Mfwhdnr.bykh = "";
                            Mfwhdnr.hjbz = "";
                            if (Mfwhdnr.zdbz.Trim() != "1")
                            {
                                Mfwhdnr.fwzh = "";
                            }


                            Tfwhdnr.Update(Mfwhdnr);

                            resultDict.Add("hdbh", hdbh);
                            resultDict.Add("errmsg", "success");
                            resultList.Add(resultDict);
                            //succeed = succeed + hdbh + "/";
                            //num = num + 1;
                        }
                        catch (Exception ex)
                        {
                            //--------------------------------------------保存失败，返回失败sqdh，下一个循环
                            errmsg = ex.Message.Replace("\r\n", "");
                            resultDict.Add("hdbh", hdbh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            //lost = lost + hdbh + "|" + errmsg + "/";
                        }
                    }
                    else
                    {
                        try
                        {
                            Tfwhdclxx.Delete(hdbh, vin, wtsh);

                            resultDict.Add("hdbh", hdbh);
                            resultDict.Add("errmsg", "success");
                            resultList.Add(resultDict);
                            //succeed = succeed + hdbh + "/";
                            //num = num + 1;
                        }
                        catch (Exception ex)
                        {
                            //--------------------------------------------保存失败，返回失败sqdh，下一个循环
                            errmsg = ex.Message.Replace("\r\n", "");
                            resultDict.Add("hdbh", hdbh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            //lost = lost + hdbh + "|" + errmsg + "/";
                        }
                    }

                }
                catch (Exception ex)
                {
                    //--------------------------------------------保存失败，返回失败sqdh，下一个循环
                    errmsg = ex.Message.Replace("\r\n", "");
                    resultDict.Add("hdbh", hdbh);
                    resultDict.Add("errmsg", errmsg);
                    resultList.Add(resultDict);
                    continue;
                }
            }
            Msg = "success";
            return resultList;
        }
        #endregion

        #region 关怀促销服务活动上传Begin
        public List<Dictionary<string, string>> importghcxfwhd(List<inputGhfwhd> hdList, ref string Msg)
        {
            if (hdList.Count == 0)
            {
                Msg = "没有活动数据";
                return null;
            }

            SIS.Model.fwzk Mfwzk = new SIS.Model.fwzk();
            SIS.BLL.fwzk Tfwzk = new SIS.BLL.fwzk();

            SIS.BLL.xhk b_xhk = new SIS.BLL.xhk();
            SIS.Model.xhk Mxhk = new SIS.Model.xhk();

            SIS.BLL.fwhd Tfwhd = new SIS.BLL.fwhd();
            SIS.Model.fwhd Mfwhd = new SIS.Model.fwhd();

            SIS.BLL.fwhdnr Tfwhdnr = new SIS.BLL.fwhdnr();
            SIS.Model.fwhdnr Mfwhdnr = new SIS.Model.fwhdnr();

            SIS.BLL.clxx Tclxx = new SIS.BLL.clxx();
            SIS.Model.clxx Mclxx = new SIS.Model.clxx();

            SIS.BLL.fwhdclxx Tfwhdclxx = new SIS.BLL.fwhdclxx();
            SIS.Model.fwhdclxx Mfwhdclxx = new SIS.Model.fwhdclxx();

            DataSet sbd_ds = new DataSet();

            string errmsg = "";

            string hdbh = "";
            string fwzh, wxfc, spfc, wsqfch, wtsh, vin, cjrq, xslcstr, bykh;
            string lxr, lxrdh;
            int xslc = 0;
            bool wsqfc_flag = false;
            string msg = "";

            List<Dictionary<string, string>> resultList = new List<Dictionary<string, string>>();
            Dictionary<string, string> resultDic;

            foreach (inputGhfwhd fwhd in hdList)
            {
                resultDic = new Dictionary<string, string>();
                try
                {
                    fwzh = fwhd.fwzh.Trim();       //服务站号
                    wxfc = fwhd.sjfc.Trim();       //维修分厂号
                    wtsh = fwhd.wtsh.Trim();       //委托书号
                    hdbh = fwhd.hdbh.Trim();       //活动编号
                    vin = fwhd.dph.Trim();         //底盘号
                    cjrq = fwhd.cjrq.Trim();       //参加日期
                    xslcstr = fwhd.xslc.Trim();    //行驶里程

                    bykh = fwhd.bykh.Trim();       //保养卡号
                    lxr = fwhd.sxr.Trim();         //送修人
                    lxrdh = fwhd.sxr_sjh.Trim();   //送修人手机

                    spfc = "";
                    #region 必填判断

                    //VIN码不能为空
                    if (vin == "")
                    {
                        errmsg = "VIN码不能为空";
                        resultDic.Add("hdbh", hdbh);
                        resultDic.Add("errmsg", errmsg);
                        resultList.Add(resultDic);
                        continue;
                    }
                    if (fwzh == "")
                    {
                        errmsg = "服务站号不能为空";
                        resultDic.Add("hdbh", hdbh);
                        resultDic.Add("errmsg", errmsg);
                        resultList.Add(resultDic);
                        continue;
                    }
                    if (DateTime.Now.ToString("yyyyMMdd").CompareTo("20160121") >= 0)
                    {
                        if (lxr == "" || lxrdh == "")
                        {
                            errmsg = "联系人和联系人手机不能为空";
                            resultDic.Add("hdbh", hdbh);
                            resultDic.Add("errmsg", errmsg);
                            resultList.Add(resultDic);
                            continue;
                        }
                    }

                    xslc = int.Parse(xslcstr);

                    #endregion

                    #region 服务站信息/车辆等判断
                    wsqfc_flag = false;
                    if (wxfc != "")
                    {
                        if (PageValidate.IsNumber(wxfc) == true && int.Parse(wxfc) >= GlobalConst.unAuthorizedFcStart && int.Parse(wxfc) <= GlobalConst.unAuthorizedFcEnd)
                        {
                            spfc = "";
                            wsqfc_flag = true;
                        }
                        else
                        {
                            spfc = wxfc;
                            wsqfc_flag = false;
                        }
                    }
                    //判断服务站是否存在
                    Mfwzk = Tfwzk.GetModel(fwzh, spfc);
                    if (Mfwzk == null)
                    {
                        errmsg = "服务站号在售后索赔系统中不存在";
                        resultDic.Add("hdbh", hdbh);
                        resultDic.Add("errmsg", errmsg);
                        resultList.Add(resultDic);
                        continue;
                    }
                    //判断是否锁定
                    if (IsLocked.IsLockfwz(Mfwzk, cjrq) == true)
                    {
                        errmsg = "服务站已解约，不能进行该操作！";
                        resultDic.Add("hdbh", hdbh);
                        resultDic.Add("errmsg", errmsg);
                        resultList.Add(resultDic);
                        continue;
                    }
                    //判断服务站是否开通了上传功能
                    if (Mfwzk.wxscbz.Trim() != "1")
                    {
                        errmsg = "服务站还没有开通上传功能";
                        resultDic.Add("hdbh", hdbh);
                        resultDic.Add("errmsg", errmsg);
                        resultList.Add(resultDic);
                        continue;
                    }
                    //判断未授权网点是否允许上传单据
                    if (wsqfc_flag == true)
                    {
                        wsqfch = Mfwzk.ktwsqfch.Trim();
                        if (wsqfch.IndexOf(wxfc) < 0)
                        {
                            errmsg = "网点" + wxfc + "未授权";
                            resultDic.Add("hdbh", hdbh);
                            resultDic.Add("errmsg", errmsg);
                            resultList.Add(resultDic);
                            continue;
                        }
                    }
                    #endregion

                    #region 车辆判断及服务站和车是否对应
                    Mclxx = Tclxx.GetModel(vin);
                    if (Mclxx == null)
                    {
                        errmsg = "车辆库中查询不到此车信息";
                        resultDic.Add("hdbh", hdbh);
                        resultDic.Add("errmsg", errmsg);
                        resultList.Add(resultDic);
                        continue;
                    }

                    //判断服务站和车是否对应
                    msg = b_xhk.IfCarInFwzh(fwzh, spfc, Mclxx.vsn.Trim(), cjrq);
                    if (string.IsNullOrEmpty(msg.Trim()) == false)
                    {
                        errmsg = msg;
                        resultDic.Add("hdbh", hdbh);
                        resultDic.Add("errmsg", errmsg);
                        resultList.Add(resultDic);
                        continue;
                    }

                    #endregion

                    #region 服务活动判断
                    Mfwhd = Tfwhd.GetModel(hdbh);
                    if (Mfwhd == null)
                    {
                        errmsg = "此活动不存在";
                        resultDic.Add("hdbh", hdbh);
                        resultDic.Add("errmsg", errmsg);
                        resultList.Add(resultDic);
                        continue;
                    }

                    msg = Tfwhd.check_fwhd_ghcx(fwzh, spfc, vin, cjrq, xslc, bykh, Mfwhd);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDic.Add("hdbh", hdbh);
                        resultDic.Add("errmsg", errmsg);
                        resultList.Add(resultDic);
                        continue;
                    }

                    #endregion

                    if (Mfwhd.cljtbz.Trim() == "1")
                    {
                        try
                        {
                            Mfwhdnr = Tfwhdnr.GetModel(hdbh, vin);

                            Mfwhdnr.fwzh = fwzh;
                            Mfwhdnr.rq = cjrq;
                            Mfwhdnr.zt = "2";
                            Mfwhdnr.hjbz = "0";

                            Mfwhdnr.jsbh = "";
                            Mfwhdnr.sqdh = wtsh;
                            Mfwhdnr.fc = wxfc;
                            Mfwhdnr.xslc = xslc;
                            Mfwhdnr.bykh = bykh;

                            Tfwhdnr.Update(Mfwhdnr);

                            try
                            {
                                // 更新车辆联系人信息
                                if (lxr != "" && lxrdh != "")
                                {
                                    Mclxx.lxr = lxr;
                                    Mclxx.lxrdh = lxrdh;
                                    Tclxx.UpdateLxr(Mclxx);
                                }
                            }
                            catch
                            {
                            }
                            resultDic.Add("hdbh", hdbh);
                            resultDic.Add("errmsg", "success");
                            resultList.Add(resultDic);
                            //succeed = succeed + hdbh + "/";
                            //num = num + 1;
                        }
                        catch (Exception ex)
                        {
                            //--------------------------------------------保存失败，返回失败sqdh，下一个循环
                            errmsg = ex.Message.Replace("\r\n", "");
                            resultDic.Add("hdbh", hdbh);
                            resultDic.Add("errmsg", errmsg);
                            resultList.Add(resultDic);
                        }
                    }
                    else
                    {
                        try
                        {
                            Mfwhdclxx = new SIS.Model.fwhdclxx();
                            Mfwhdclxx.bh = hdbh;
                            Mfwhdclxx.dph = vin.ToUpper();
                            Mfwhdclxx.fwzh = fwzh.ToUpper();
                            Mfwhdclxx.hdlx = "2";
                            Mfwhdclxx.rq = cjrq;
                            Mfwhdclxx.lzrq = Mclxx.lzrq.Trim();
                            Mfwhdclxx.scrq = Mclxx.scrq.Trim();
                            Mfwhdclxx.sqdh = wtsh;
                            Mfwhdclxx.xh = Mfwhdclxx.xh.Trim();
                            Mfwhdclxx.zydh = "";

                            Mfwhdclxx.jsbh = "";
                            Mfwhdclxx.fc = wxfc;
                            Mfwhdclxx.xslc = xslc;
                            Mfwhdclxx.hjbz = "0";
                            Mfwhdclxx.bykh = bykh;

                            Tfwhdclxx.Add(Mfwhdclxx);

                            try
                            {
                                // 更新车辆联系人信息
                                if (lxr != "" && lxrdh != "")
                                {
                                    Mclxx.lxr = lxr;
                                    Mclxx.lxrdh = lxrdh;
                                    Tclxx.UpdateLxr(Mclxx);
                                }
                            }
                            catch
                            {
                            }
                            resultDic.Add("hdbh", hdbh);
                            resultDic.Add("errmsg", "success");
                            resultList.Add(resultDic);
                            //succeed = succeed + hdbh + "/";
                            //num = num + 1;
                        }
                        catch (Exception ex)
                        {
                            //--------------------------------------------保存失败，返回失败sqdh，下一个循环
                            errmsg = ex.Message.Replace("\r\n", "");
                            resultDic.Add("hdbh", hdbh);
                            resultDic.Add("errmsg", errmsg);
                            resultList.Add(resultDic);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //--------------------------------------------保存失败，返回失败sqdh，下一个循环
                    errmsg = ex.Message.Replace("\r\n", "");
                    resultDic.Add("hdbh", hdbh);
                    resultDic.Add("errmsg", errmsg);
                    resultList.Add(resultDic);
                    continue;
                }
            }

            Msg = "success";
            return resultList;

        }

        #endregion

        #region 获取车辆可参加的关怀促销活动
        public List<Dictionary<string, string>> getghcxfwhd(string fwzh, string fch, string dph, ref string Msg)
        {
            if (dph.Trim().Length != 17 || fwzh.Trim() == "")
            {
                Msg = "服务站号或VIN不正确";
                return null;
            }
            SIS.BLL.clxx Bclxx = new SIS.BLL.clxx();
         
            string msg = "";
            List<Dictionary<string, string>> list = Bclxx.get_allfwhd_ghcx_List(dph, fwzh, fch, ref msg);

            Msg = msg;

            return list;
        }
        #endregion

        #region 关怀促销活动参与状态查询
        public List<Dictionary<string, string>> queryghcxfwhd(string fwzh, string fch, string vin, string hdbhs, ref string errmsg)
        {
            
            SIS.BLL.fwhd Tfwhd = new SIS.BLL.fwhd();
            SIS.Model.fwhd Mfwhd = new SIS.Model.fwhd();

            SIS.BLL.fwhdnr Tfwhdnr = new SIS.BLL.fwhdnr();
            SIS.Model.fwhdnr Mfwhdnr = new SIS.Model.fwhdnr();

            SIS.BLL.fwhdclxx Tfwhdclxx = new SIS.BLL.fwhdclxx();
            DataSet fwhdclxxDs = new DataSet();

            SIS.Model.fwzk Mfwzk = new SIS.Model.fwzk();
            SIS.BLL.fwzk Tfwzk = new SIS.BLL.fwzk();

            SIS.BLL.xhk b_xhk = new SIS.BLL.xhk();
            SIS.Model.xhk Mxhk = new SIS.Model.xhk();

            string msg = "";
            bool wsqfc_flag = false;
            string wxfc = "", spfc = "", wsqfch = "";

            //VIN码不能为空
            if (vin == "")
            {
                errmsg = "VIN码不能为空";
                return null;
            }
            if (fwzh == "")
            {
                errmsg = "服务站号不能为空";
                return null;
            }
            if (hdbhs == "")
            {
                errmsg = "活动编号不能为空";
                return null;
            }

            #region 服务站信息/车辆等判断
            wsqfc_flag = false;
            if (wxfc != "")
            {
                if (PageValidate.IsNumber(wxfc) == true && int.Parse(wxfc) >= GlobalConst.unAuthorizedFcStart && int.Parse(wxfc) <= GlobalConst.unAuthorizedFcEnd)
                {
                    spfc = "";
                    wsqfc_flag = true;
                }
                else
                {
                    spfc = wxfc;
                    wsqfc_flag = false;
                }
            }
            //判断服务站是否存在
            Mfwzk = Tfwzk.GetModel(fwzh, spfc);
            if (Mfwzk == null)
            {
                errmsg = "服务站号在售后索赔系统中不存在";
                return null;
            }
            //判断是否锁定
            if (IsLocked.IsLockfwz(Mfwzk) == true)
            {
                errmsg = "服务站已冻结或不在合同期内";
                return null;
            }
            //判断服务站是否开通了上传功能
            if (Mfwzk.wxscbz.Trim() != "1")
            {
                errmsg = "服务站还没有开通上传功能";
                return null;
            }
            //判断未授权网点是否允许上传单据
            if (wsqfc_flag == true)
            {
                wsqfch = Mfwzk.ktwsqfch.Trim();
                if (wsqfch.IndexOf(wxfc) < 0)
                {
                    errmsg = "网点" + wxfc + "未授权";
                    return null;
                }
            }
            #endregion

            string hdbh = "", hdlx = "";
            string tmpfwzh = "", tmpfch = "";
            string[] hdbhArray = hdbhs.Split(new char[] { ',' });

            List<Dictionary<string, string>> hdList = new List<Dictionary<string, string>>();
            Dictionary<string, string> dt;
            for (int i = 0; i < hdbhArray.Length; i++)
            {
                dt = new Dictionary<string, string>();

                hdbh = hdbhArray[i];
                Mfwhd = Tfwhd.GetModel(hdbh);
                if (Mfwhd != null)
                {
                    hdlx = Mfwhd.hdlx.Trim();
                    if (hdlx != "关怀促销")
                    {
                        msg = "不是关怀促销活动";
                        dt.Add("hdbh", hdbh);
                        dt.Add("hdsm", msg);
                        hdList.Add(dt);
                        continue;
                    }
                    if (Mfwhd.cljtbz.Trim() == "1")
                    {
                        Mfwhdnr = Tfwhdnr.GetModel(hdbh, vin);
                        if (Mfwhdnr.zt == "2")
                        {
                            tmpfwzh = Mfwhdnr.fwzh.Trim();
                            tmpfch = Mfwhdnr.fc.Trim();
                            if (tmpfwzh == fwzh && tmpfch == fch)
                            {
                                msg = "已参加";
                            }
                            else
                            {
                                if (tmpfwzh == fwzh && tmpfch != fch)
                                {
                                    msg = "此车已在其他分站参加活动";
                                }
                                else
                                {
                                    msg = "此车已在其他站参加活动";
                                }
                            }
                        }
                        else
                        {
                            msg = "未参加";
                        }
                        dt.Add("hdbh", hdbh);
                        dt.Add("hdsm", msg);
                        hdList.Add(dt);
                    }
                    else
                    {
                        fwhdclxxDs = Tfwhdclxx.GetList(" bh='" + hdbh + "' and dph='" + vin + "'");
                        if (fwhdclxxDs.Tables[0].Rows.Count > 0)
                        {
                            tmpfwzh = fwhdclxxDs.Tables[0].Rows[0]["fwzh"].ToString().Trim();
                            tmpfch = fwhdclxxDs.Tables[0].Rows[0]["fc"].ToString().Trim();
                            if (tmpfwzh == fwzh && tmpfch == fch)
                            {
                                msg = "已参加";
                            }
                            else
                            {
                                if (tmpfwzh == fwzh && tmpfch != fch)
                                {
                                    msg = "此车已在其他分站参加活动";
                                }
                                else
                                {
                                    msg = "此车已在其他站参加活动";
                                }
                            }
                          
                        }
                        else
                        {
                            msg = "未参加";
                        }
                        dt.Add("hdbh", hdbh);
                        dt.Add("hdsm", msg);
                        hdList.Add(dt);
                    }
                }
                else
                {
                    msg = "此活动已不存在";
                    dt.Add("hdbh", hdbh);
                    dt.Add("hdsm", msg);
                    hdList.Add(dt);
                }
            }

            errmsg = "success";
            return hdList;

        }
        #endregion

        #region 判断车辆是否是活动车辆
        public string chk_fwhdTx(string dph, string fwzh, ref string Msg)
        {
            string xh, scrq, lzrq;
            int xslc;

            try
            {
                SIS.BLL.clxx bllclxx = new SIS.BLL.clxx();
                SIS.Model.clxx modelclxx = bllclxx.GetModel(dph.Trim());

                if (modelclxx == null)
                {
                    Msg = "车辆不存在";
                    return "";
                }
                else
                {
                    xh = modelclxx.vsn.Trim().Substring(0, 4);
                    scrq = modelclxx.scrq.Replace("-", "").Replace("_", "").Trim();
                    lzrq = modelclxx.lzrq.Replace("-", "").Replace("_", "").Trim();
                    xslc = modelclxx.mile;
                }
                Msg = "success";
                string tmsg = bllclxx.chk_fwhdTx(dph.Trim(), xh, scrq, lzrq, xslc, fwzh);
                return tmsg;
            }
            catch
            {
                Msg = "查询活动信息异常";
                return "";
            }
        }
        #endregion

        #region 单据撤回
        public string Cxdj(string type, string fwzh, string fch, string sqdh)
        {
            string zt, jjrmc = "";
            if (type != "spd" && type != "sbd" && type != "wts")
            {
                return "参数不正确";
            }
            if (sqdh.Trim().Length != 10)
            {
                return "参数不正确";
            }
            try
            {
                SIS.Model.fwzk Mfwzk = new SIS.Model.fwzk();
                SIS.BLL.fwzk Bfwzk = new SIS.BLL.fwzk();
                Mfwzk = Bfwzk.GetModel(fwzh, fch);
                if (Mfwzk == null)
                {
                    return "服务站号在售后索赔系统中不存在";
                }
                else
                {
                    if (IsLocked.IsLockfwz(Mfwzk) == true)
                    {
                        return "服务站已冻结或不在合同期内，无法进行此操作";
                    }
                }

                if (type == "spd")
                {
                    SIS.BLL.gzd gzd = new SIS.BLL.gzd();
                    SIS.Model.gzd Mgzd = new SIS.Model.gzd();

                    Mgzd = gzd.GetModel(fwzh.Trim(), sqdh.Trim());
                    if (Mgzd != null)
                    {
                        zt = Mgzd.zt.Trim();
                        jjrmc = Mgzd.jjrmc.Trim();
                        if (zt == "1")
                        {
                            Mgzd.zt = "9";
                        }
                        else if (zt == "2" && jjrmc == "【自动】")
                        {
                            Mgzd.zt = "9";
                            Mgzd.jjbz = "";
                            Mgzd.jjrdm = "";
                            Mgzd.jjrmc = "";
                            Mgzd.jjsm = "";
                        }
                        else
                        {
                            return "只能撤回状态为未审件的索赔单";
                        }
                        Mgzd.jdrq = "";
                        gzd.Update(Mgzd);
                        return "success";
                    }
                    else
                    {
                        return "售后索赔系统中不存在此索赔单";
                    }
                }
                else if (type == "sbd")
                {
                    SIS.BLL.sbd sbd = new SIS.BLL.sbd();
                    SIS.Model.sbd Msbd = new SIS.Model.sbd();

                    Msbd = sbd.GetModel(fwzh.Trim(), sqdh.Trim());
                    if (Msbd != null)
                    {
                        zt = Msbd.zt.Trim();
                        if (zt == "1" || zt == "4")
                        {
                            Msbd.zt = "9";
                            Msbd.jdrq = "";
                            sbd.Update(Msbd);
                            return "success";
                        }
                        else
                        {
                            return "只能撤回状态为未审核的保养单";
                        }
                    }
                    else
                    {
                        return "售后索赔系统中不存在此保养单";
                    }
                }
                else if (type == "wts")
                {
                    SIS.BLL.T_WTS wts = new SIS.BLL.T_WTS();
                    SIS.Model.T_WTS Mwts;

                    Mwts = wts.GetModel(fwzh.Trim(), fch.Trim(), sqdh.Trim());
                    if (Mwts != null)
                    {
                        zt = Mwts.SHSCBZ.Trim();
                        if (zt == "1")
                        {
                            Mwts.SHSCBZ = "9";
                            wts.Update(Mwts);
                            return "success";
                        }
                        else
                        {
                            return "只能撤回状态为已提交的工单";
                        }
                    }
                    else
                    {
                        return "售后索赔系统中不存在此工单";
                    }
                }
                else
                    return "参数不正确";
            }
            catch
            {
                return "撤销失败";
            }
        }
        #endregion

        #region 单据作废
        public string Zfdj(string type, string fwzh, string fch, string sqdh)
        {
            string zt = string.Empty;
            if (type != "spd" && type != "sbd" && type != "wts")
            {
                return "参数不正确";
            }
            if (sqdh.Trim().Length != 10)
            {
                return "参数不正确";
            }
            try
            {
                SIS.Model.fwzk Mfwzk = new SIS.Model.fwzk();
                SIS.BLL.fwzk Bfwzk = new SIS.BLL.fwzk();
                Mfwzk = Bfwzk.GetModel(fwzh.Trim(), fch.Trim());
                if (Mfwzk == null)
                {
                    return "服务站号在售后索赔系统中不存在";
                }
                else
                {
                    if (IsLocked.IsLockfwz(Mfwzk) == true)
                    {
                        return "服务站已冻结或不在合同期内，无法进行此操作";
                    }
                }

                if (type == "spd")
                {
                    SIS.BLL.gzd gzd = new SIS.BLL.gzd();
                    SIS.Model.gzd Mgzd = new SIS.Model.gzd();

                    Mgzd = gzd.GetModel(fwzh.Trim(), sqdh.Trim());
                    if (Mgzd != null)
                    {
                        if (Mgzd.wxscbz.Trim() == "1")
                        {
                            zt = Mgzd.zt.Trim();
                            if (zt == "8")
                            {
                                Mgzd.zt = "0";
                            }
                            else
                            {
                                return "只能作废状态为被返回的索赔单";
                            }
                            gzd.Update(Mgzd);
                            return "success";
                        }
                        else
                        {
                            return "此单不是由售后服务管理系统上传";
                        }
                    }
                    else
                    {
                        return "售后索赔系统中不存在此索赔单";
                    }
                }
                else if (type == "sbd")
                {
                    SIS.BLL.sbd sbd = new SIS.BLL.sbd();
                    SIS.Model.sbd Msbd = new SIS.Model.sbd();

                    Msbd = sbd.GetModel(fwzh.Trim(), sqdh.Trim());
                    if (Msbd != null)
                    {
                        if (Msbd.wxscbz.Trim() == "1")
                        {
                            zt = Msbd.zt.Trim();
                            if (zt == "8")
                            {
                                Msbd.zt = "0";
                            }
                            else
                            {
                                return "只能作废状态为被返回的保养单";
                            }
                            sbd.Update(Msbd);
                            return "success";
                        }
                        else
                        {
                            return "此单不是由售后服务管理系统上传的";
                        }
                    }
                    else
                    {
                        return "售后索赔系统中不存在此保养单";
                    }
                }
                else if (type == "wts")
                {
                    return "";
                }
                else
                {
                    return "参数不正确";
                }
            }
            catch
            {
                return "作废失败";
            }

        }
        #endregion

        #region 写回索赔单信息
        public Dictionary<string, object> GetSpd(string fwzh, string sqdh, ref string Msg)
        {
            if (fwzh.Trim() == "" || sqdh.Trim() == "" || sqdh.Trim().Length != 10)
            {
                Msg = "服务站号或申请单号不正确";
                return null;
            }
            try
            {
                SIS.BLL.gzd gzd = new SIS.BLL.gzd();
                SIS.Model.gzd Mgzd = new SIS.Model.gzd();
                Mgzd = gzd.GetModel(fwzh.Trim(), sqdh.Trim());

                Dictionary<string,object> dt = new Dictionary<string,object>();
                if (Mgzd != null)
                {
                    dt = gzdModelToDict(Mgzd);
                    Msg = "success";
                    return dt;
                }
                else
                {
                    Msg = "查询不到此索赔单信息";
                    return null;
                }
            }
            catch
            {
                Msg = "查询索赔单信息异常";
                return null;
            }
        }
        #endregion

        #region 核对索赔单
        public Dictionary<string, object> GetSpd_Wxsqdh(string fwzh, string wxsqdh, string fch, ref string Msg)
        {
            fwzh = fwzh.Trim();
            wxsqdh = wxsqdh.Trim();
            fch = fch.Trim();

            if (fwzh.Trim() == "" || wxsqdh.Trim() == "" || wxsqdh.Trim().Length != 10)
            {
                Msg = "服务站号或申请单号不正确";
                return null;
            }

            try
            {
                SIS.BLL.gzd gzd = new SIS.BLL.gzd();
                SIS.Model.gzd Mgzd = new SIS.Model.gzd();
                Mgzd = gzd.GetModelByWxsqdh(fwzh.Trim(), fch.Trim(), wxsqdh.Trim());

                Dictionary<string, object> dt = new Dictionary<string, object>();
                if (Mgzd != null)
                {
                    dt = gzdModelToDict(Mgzd);
                    Msg = "success";
                    return dt;
                }
                else
                {
                    Msg = "查询不到此索赔单信息";
                    return null;
                }
            }
            catch
            {
                Msg = "查询索赔单信息异常";
                return null;
            }
        }
        #endregion

        #region 写回保养单信息
        public Dictionary<string, string> Getsbd(string fwzh, string sqdh, ref string Msg)
        {
           
            if (fwzh.Trim() == "" || sqdh.Trim() == "" || sqdh.Trim().Length != 10)
            {
                Msg = "服务站号或申请单号不正确";
                return null;
            }

            Dictionary<string, string> ht = new Dictionary<string, string>();

            try
            {
                SIS.BLL.sbd sbd = new SIS.BLL.sbd();
                SIS.Model.sbd Msbd = new SIS.Model.sbd();

                Msbd = sbd.GetModel(fwzh.Trim(), sqdh.Trim());
                if (Msbd != null)
                {
                    ht.Add("fwzh", Msbd.fwzh.Trim());
                    ht.Add("sqdh", Msbd.sqdh.Trim());
                    ht.Add("zt", Msbd.zt.Trim());
                    ht.Add("shbz", Msbd.shbz.Trim());
                    ht.Add("shrq", Msbd.shrq.Trim());
                    ht.Add("shrmc", Msbd.shrmc.Trim());
                    ht.Add("sm", Msbd.sm.Trim());
                    ht.Add("sm1", Msbd.sm1.Trim());
                    ht.Add("shrq2", Msbd.shrq2.Trim());
                    ht.Add("shrmc2", Msbd.shrmc2.Trim());
                    ht.Add("sm2", Msbd.sm2.Trim());
                    ht.Add("jsbz", Msbd.jsbz.Trim());
                    ht.Add("jsbh", Msbd.jsbh.Trim());
                    ht.Add("jsrq", Msbd.jsrq.Trim());
                    ht.Add("byje", Msbd.byje.ToString());

                    Msg = "success";
                    return ht;

                    //Msg = zt + "|" + shbz + "|" + shrq + "|" + shrmc + "|" + sm + "|" + sm1 + "|" + shrq2 + "|" + shrmc2 + "|" + sm2 + "|" + jsbz + "|" + jsbh + "|" + jsrq + "|" + byje + "|";
                }
                else
                {
                    Msg = "查询不到保养单";
                    return null;
                }
            }
            catch
            {
                Msg = "查询保养单异常";
                return null;
            }
        }
        #endregion

        #region 核对保养单
        public Dictionary<string, string> GetSbd_Wxsqdh(string fwzh, string wxsqdh, string fch, ref string msg)
        {
            fwzh = fwzh.Trim();
            wxsqdh = wxsqdh.Trim();
            fch = fch.Trim();

           
            if (fwzh == "" || wxsqdh == "" || wxsqdh.Length != 10)
            {
                msg = "服务站号或申请单号不正确";
                return null;
            }

            try
            {
                SIS.BLL.sbd sbd = new SIS.BLL.sbd();

                Dictionary<string, string> dt = new Dictionary<string, string>();
                SIS.Model.sbd Msbd = sbd.GetModelByWxsqdh(fwzh, fch, wxsqdh);
                if (Msbd != null)
                {
                    dt.Add("fwzh", Msbd.fwzh.Trim());
                    dt.Add("sqdh", Msbd.sqdh.Trim());
                    dt.Add("zt", Msbd.zt.Trim());
                    dt.Add("shbz", Msbd.shbz.Trim());
                    dt.Add("shrq", Msbd.shrq.Trim());
                    dt.Add("shrmc", Msbd.shrmc.Trim());
                    dt.Add("sm", Msbd.sm.Trim());
                    dt.Add("sm1", Msbd.sm1.Trim());
                    dt.Add("shrq2", Msbd.shrq2.Trim());
                    dt.Add("shrmc2", Msbd.shrmc2.Trim());
                    dt.Add("sm2", Msbd.sm2.Trim());
                    dt.Add("jsbz", Msbd.jsbz.Trim());
                    dt.Add("jsbh", Msbd.jsbh.Trim());
                    dt.Add("jsrq", Msbd.jsrq.Trim());
                    dt.Add("byje", Msbd.byje.ToString());

                    msg = "success";
                    return dt;
                    //Msg = zt + "|" + shbz + "|" + shrq + "|" + shrmc + "|" + sm + "|" + sm1 + "|" + shrq2 + "|" + shrmc2 + "|" + sm2 + "|" + jsbz + "|" + jsbh + "|" + jsrq + "|" + byje + "|" + sqdh + "|";

                }
                else
                {
                    msg = "查询不到保养单";
                    return null;
                }
            }
            catch
            {
                msg = "查询保养单异常";
                return null;
            }
        }
        #endregion

        #region 获取指定服务站在购车日期范围内车辆信息
        public List<Dictionary<string, string>> getClxxByDealer(string fwzh, string fch, string lzrq1, string lzrq2, ref string msg)
        {
            string jxsdm = "";
            try
            {
                if (fwzh.Length < 7 || fwzh.Length > 10)
                {
                    msg = "服务站号不符合要求";
                    return null;
                }
                if (lzrq1.Length != 8 || lzrq2.Length != 8)
                {
                    msg = "日期格式不正确";
                    return null;
                }

                SIS.BLL.fwzk Bfwzk = new SIS.BLL.fwzk();
                fch = Bfwzk.getRealFch(fch);
                SIS.Model.fwzk Mfwzk = Bfwzk.GetModel(fwzh, fch);
                if (Mfwzk == null)
                {
                    msg = "服务站号不存在";
                    return null;
                }
                jxsdm = Mfwzk.jxsdm.Trim();
                if (jxsdm == "")
                {
                    msg = "对应的经销商号未设置";
                    return null;
                }
                //判断是否锁定
                if (IsLocked.IsLockfwz(Mfwzk, "") == true)
                {
                    msg = "服务站已解约，不能进行该操作！";
                    return null;
                }

                // 查询车辆信息
                SIS.BLL.clxx Tclxx = new SIS.BLL.clxx();
                List<Dictionary<string,string>> list = Tclxx.GetListByJxs_New(jxsdm, lzrq1, lzrq2);
                msg = "success";
                return list;
            }
            catch (Exception ex)
            {
                msg = "查询车辆信息异常：" + ex.Message.Trim();
                return null;
            }
        }
        #endregion

        #region 获取车辆信息
        public Dictionary<string, string> GetClxx(string dph, ref string Msg)
        {
          
            if (dph.Trim().Length != 17)
            {
                Msg = "VIN不正确";
                return null;
            }
            SIS.BLL.clxx Bclxx = new SIS.BLL.clxx();
            try
            {
                Dictionary<string, string> clxxDict = Bclxx.get_clxx_only(dph);
                if (clxxDict == null)
                    Msg = "无此车辆信息";
                else
                    Msg = "success";
                return clxxDict;
            }
            catch
            {
                Msg = "查询车辆信息异常";
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 检查服务站合同是否已到期或已冻结
        /// </summary>
        /// <param name="fwzh"></param>
        /// <param name="fch"></param>
        /// <param name="rq"></param>
        /// <returns></returns>
        public string checkFwzExpire(string fwzh, string fch, string rq)
        {
            string errmsg = string.Empty;
            if (rq == null || rq.Trim() == "")
            {
                rq = DateTime.Now.ToString("yyyyMMdd");
            }
            SIS.BLL.fwzk Tfwzk = new BLL.fwzk();
            //判断服务站是否存在
            SIS.Model.fwzk Mfwzk = Tfwzk.GetModel(fwzh, fch);
            if (Mfwzk == null)
            {
                errmsg = "服务站号不正确";
            }
            else
            {
                //判断是否锁定
                if (IsLocked.IsLockfwz(Mfwzk, rq) == true)
                {
                    errmsg = "服务站已解约，不能进行该操作！";
                }
            }
            return errmsg;
        }

        #region 获取车辆信息及JDPower
        public Dictionary<string, string> GetClxx2(string dph, string fwzh, string fch, ref string Msg)
        {
            if (dph.Trim().Length != 17)
            {
                Msg = "VIN不正确";
                return null;
            }
            Msg = checkFwzExpire(fwzh, fch, "");
            if (Msg != "")
            {
                return null;
            }
            SIS.BLL.clxx Bclxx = new SIS.BLL.clxx();
            try
            {
                Dictionary<string, string> clxxDict = Bclxx.get_clxx_allinfo(dph, fwzh, fch);
                if (clxxDict == null)
                    Msg = "无此车辆信息";
                else
                    Msg = "success";
                return clxxDict;
            }
            catch
            {
                Msg = "查询车辆信息异常";
                return null;
            }
        }
        #endregion

        #region 获取车辆保养单记录
        public DataTable GetSbdRecords(string fwzh, string vin, ref string Msg)
        {
            SIS.BLL.sbd Bsdb = new BLL.sbd();

            try
            {
                DataSet ds = Bsdb.getSbdRecords(vin, fwzh, "");
                Msg = "success";
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Msg = "获取车辆保养记录异常：" + ex.Message.Trim();
                return null;
            }
        }
        #endregion

        #region 获取车辆索赔单记录
        public DataTable GetGzdRecords(string fwzh, string vin, ref string Msg)
        {
            SIS.BLL.gzd Bgzd = new BLL.gzd();

            try
            {
                DataSet ds = Bgzd.getRecords(vin, fwzh, "");
                Msg = "success";
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Msg = "获取车辆索赔记录异常：" + ex.Message.Trim();
                return null;
            }
        }
        #endregion

        #region 委托书上传
        //---------------------------------工单导入
        public List<Dictionary<string, string>> insertWts(List<inputWts> wtsList, ref string Msg)
        {
            if (wtsList.Count == 0)
            {
                Msg = "没有需要上传的委托书";
                return null;
            }
           
            string errmsg = "$", msg = "";
            string wtsh = "", fwzh = "", spfc = "", wxfc = "";

            SIS.Model.T_WTS Mwts = new SIS.Model.T_WTS();
            SIS.BLL.T_WTS Twts = new SIS.BLL.T_WTS();

            SIS.BLL.fwzk Tfwzk = new SIS.BLL.fwzk();
            SIS.Model.fwzk Mfwzk = new SIS.Model.fwzk();

            SIS.BLL.clxx Tclxx = new SIS.BLL.clxx();
            SIS.Model.clxx mclxx = new SIS.Model.clxx();

            SIS.BLL.xhk b_xhk = new SIS.BLL.xhk();
            SIS.Model.xhk Mxhk = new SIS.Model.xhk();

            string flag = "New";
            string dph, jzrq, jzsj, dw_cz, dz, yb, sjh, cph, clys, vsn, fdjh, xh, sxr, lzrq, sbrq, scrq, kdrq, kdrq2, kdsj, hlcbrq, server_rq;
            string jclc, hblc, xslc, xcbylc, xllb, lzrq_clxx, xh_clxx, xh_xhk, sqwxycscbz;
            bool hlcbbz, spjdbz;
            string wsqfch = "";
            bool wsqfc_flag = false;

            List<Dictionary<string, string>> resultList = new List<Dictionary<string, string>>();
            Dictionary<string, string> resultDict = null;

            //-------------------------------------------------主表循环
            foreach (inputWts DT_wts in wtsList)
            {
                try
                {
                    resultDict = new Dictionary<string, string>();
                    //----------------------------------------------------------------------
                    fwzh = DT_wts.FWZH.Trim();
                    wxfc = DT_wts.FC.Trim();
                    wtsh = DT_wts.WTSH.Trim();
                    lzrq = DT_wts.GCRQ.Trim();
                    sbrq = DT_wts.SBRQ.Trim();
                    scrq = DT_wts.SCRQ.Trim();
                    kdrq = DT_wts.JZRQ.Trim();    //进站日期/开单日期
                    kdsj = DT_wts.JZSJ.Trim();    //进站时间/开单时间
                    jzrq = DT_wts.KDRQ.Trim();    //修理日期（维修系统中的开单日期实为维修日期）
                    jzsj = DT_wts.KDSJ.Trim();    //修理时间

                    dph = DT_wts.DPH.Trim().ToUpper();
                    vsn = DT_wts.VSN.Trim().ToUpper();
                    fdjh = DT_wts.FDJH.Trim().ToUpper();
                    xh = DT_wts.XH.Trim().ToUpper();
                    dw_cz = DT_wts.DW_CZ.Trim();
                    dz = DT_wts.DZ.Trim();
                    yb = DT_wts.YB.Trim();
                    sjh = DT_wts.SJH.Trim();
                    sxr = DT_wts.SXR.Trim();
                    cph = DT_wts.CPH.Trim();
                    clys = DT_wts.CLYS.Trim();

                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["HLCBBZ"].ToString()))  //换里程表标志
                    //    hlcbbz = false;
                    //else
                    //    hlcbbz = Boolean.Parse(DT_wts.Rows[i]["HLCBBZ"].ToString());

                    hlcbbz = DT_wts.HLCBBZ; //换里程表标志

                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["SPJDBZ"].ToString()))
                    //    spjdbz = false;
                    //else
                    //    spjdbz = Boolean.Parse(DT_wts.Rows[i]["SPJDBZ"].ToString());

                    spjdbz = DT_wts.SPJDBZ;

                    hlcbrq = DT_wts.HLCBRQ.Trim();

                    xllb = DT_wts.XLLB_DM.Trim();

                    jclc = DT_wts.JCLC.ToString();
                    hblc = DT_wts.HBLC.ToString().Trim();
                    xslc = DT_wts.XSLC.ToString().Trim();
                    xcbylc = DT_wts.XCBYLC.ToString().Trim();

                    server_rq = DateTime.Now.ToString("yyyyMMdd");
                    sqwxycscbz = "";
                    spfc = "";

                    #region 必填判断
                    if (dph == "")
                    {
                        errmsg = "VIN码不能为空";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (vsn == "")
                    {
                        errmsg = "VSN码不能为空";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (vsn.Length < 4)
                    {
                        errmsg = "VSN码小于4位";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (fdjh == "")
                    {
                        errmsg = "发动机号不能为空";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (scrq == "")
                    {
                        errmsg = "生产日期不能为空";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //if (dw_cz == "")
                    //{
                    //    errmsg = "车主不能为空";
                    //    lost = lost + wtsh + "|" + errmsg + "/";
                    //    continue;
                    //}
                    //if (dz == "")
                    //{
                    //    errmsg = "地址不能为空";
                    //    lost = lost + wtsh + "|" + errmsg + "/";
                    //    continue;
                    //}
                    //if (sjh == "")
                    //{
                    //    errmsg = "车主电话不能为空";
                    //    lost = lost + wtsh + "|" + errmsg + "/";
                    //    continue;
                    //}
                    //if (sxr == "")
                    //{
                    //    errmsg = "送修人不能为空";
                    //    lost = lost + wtsh + "|" + errmsg + "/";
                    //    continue;
                    //}
                    #endregion

                    #region 里程/分厂判断
                    //接车里程是否正确
                    if (jclc != "" && PageValidate.IsNumber(jclc) == false)
                    {
                        errmsg = "无效的表示里程，必须为整数";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //换表里程
                    if (hblc != "" && PageValidate.IsNumber(hblc) == false)
                    {
                        errmsg = "无效的换表里程，必须为整数";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //累计里程
                    if (xslc != "" && PageValidate.IsNumber(xslc) == false)
                    {
                        errmsg = "无效的累计里程，必须为整数";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //下次保养里程
                    if (xcbylc != "" && PageValidate.IsNumber(xcbylc) == false)
                    {
                        errmsg = "无效的下次保养里程，必须为整数";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //分厂判断
                    if (wxfc != "" && PageValidate.IsFCHCode(wxfc) == false)
                    {
                        errmsg = "无效的分厂号，必须为数字或字母";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    #endregion

                    #region 工单中车辆信息与车辆信息中信息比较
                    if (SIS.Common.PageValidate.IsVINCode(dph) == false)
                    {
                        errmsg = "VIN码格式不正确";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    mclxx = Tclxx.GetModel(dph);
                    if (mclxx == null)
                    {
                        errmsg = "车辆库中不存在该车辆信息";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (mclxx.spbz.Trim() != "1")
                    {
                        errmsg = "此车为不索赔车辆不能上传";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //7:-------------------------------------------------VSN码与车辆库中的VSN码不一致！
                    if (mclxx.vsn.Trim().ToUpper() != vsn)
                    {
                        errmsg = "VSN码与车辆库中的VSN码不一致";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //---------------------------------------------------车型与品种代码中的车型不一致
                    xh_clxx = mclxx.xh.Trim().ToUpper();
                    Mxhk = b_xhk.GetModel(vsn.Substring(0, 4));
                    if (Mxhk == null)
                    {
                        errmsg = "VSN码对应的品种代码不能找到";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    else
                    {
                        xh_xhk = Mxhk.xhbh.Trim().ToUpper();
                        if (xh_xhk != xh)
                        {
                            errmsg = "车型与品种代码中的车型不一致";
                            resultDict.Add("wtsh", wtsh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                        if (xh_xhk != xh_clxx)
                        {
                            xh_clxx = "";
                        }
                    }
                    //8:-------------------------------------------------发动机号与车辆库中的发动机号不一致！
                    if (mclxx.fdjh.Trim().ToUpper() != fdjh)
                    {
                        errmsg = "发动机号与车辆库中的发动机号不一致";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //9:-------------------------------------------------开票日期是否一致
                    lzrq_clxx = mclxx.lzrq.Trim();

                    if (((lzrq == "") && (lzrq_clxx != "") && (lzrq_clxx != "______")) && (int.Parse(jzrq) < int.Parse(lzrq_clxx)))
                    {
                        //--售前维修索赔单后来提交时，不需要判断开票日期是否一致，提交时不需要更新车辆信息
                        sqwxycscbz = "1";
                    }
                    else
                    {
                        if ((lzrq != lzrq_clxx) && (lzrq_clxx != "") && (lzrq_clxx != "______"))
                        {
                            errmsg = "开票日期与车辆库中的开票日期不一致";
                            resultDict.Add("wtsh", wtsh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }
                    //10:-------------------------------------------------生产日期是否一致
                    if (mclxx.scrq.Trim() != scrq)
                    {
                        errmsg = "生产日期与车辆库中的生产日期不一致";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    #endregion

                    #region 逻辑判断

                    //日期逻辑判断
                    msg = gd_chkrq(jzrq, lzrq, sbrq, scrq, kdrq);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    wsqfc_flag = false;
                    if (wxfc != "")
                    {
                        if (PageValidate.IsNumber(wxfc) == true && int.Parse(wxfc) >= GlobalConst.unAuthorizedFcStart && int.Parse(wxfc) <= GlobalConst.unAuthorizedFcEnd)
                        {
                            spfc = "";
                            wsqfc_flag = true;
                        }
                        else
                        {
                            spfc = wxfc;
                            wsqfc_flag = false;
                        }
                    }


                    //判断服务号
                    Mfwzk = Tfwzk.GetModel(fwzh, spfc);
                    if (Mfwzk == null)
                    {
                        errmsg = "服务站号在售后索赔系统中不存在";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断是否锁定
                    if (IsLocked.IsLockfwz(Mfwzk, jzrq) == true)
                    {
                        errmsg = "服务站已解约，不能进行该操作！";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断服务站是否开通了上传功能
                    if (Mfwzk.wxscbz.Trim() != "1")
                    {
                        errmsg = "服务站还没有开通上传功能";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断未授权网点是否允许上传单据
                    if (wsqfc_flag == true)
                    {
                        wsqfch = Mfwzk.ktwsqfch.Trim();
                        if (wsqfch.IndexOf(wxfc) < 0)
                        {
                            errmsg = "网点" + wxfc + "未授权";
                            resultDict.Add("wtsh", wtsh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }

                    //判断修理日期是否在开单日期前七天范围内
                    //if (Mfwzk.xlrqbz.Trim() != "1")
                    //{
                    //    kdrq_dt = new DateTime(int.Parse(kdrq.Substring(0, 4)), int.Parse(kdrq.Substring(4, 2)), int.Parse(kdrq.Substring(6, 2)));
                    //    kdrq2 = kdrq_dt.AddDays(-7).ToString("yyyyMMdd");
                    //    if (int.Parse(jzrq) > int.Parse(kdrq) || int.Parse(jzrq) < int.Parse(kdrq2))
                    //    {
                    //        errmsg = "修理日期不在开单日期前7天范围内";
                    //        lost = lost + wtsh + "|" + errmsg + "/";
                    //        continue;
                    //    }
                    //}

                    //判断服务站和车是否对应
                    msg = b_xhk.IfCarInFwzh(fwzh, spfc, vsn, jzrq);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (DT_wts.ZT != "已结算")
                    {
                        errmsg = "只有状态为“已结算”委托书才能上传";
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    #endregion

                    //是否已存在
                    Mwts = Twts.GetModel(fwzh, wxfc, wtsh);

                    if (Mwts == null)
                    {
                        flag = "New";
                        Mwts = new SIS.Model.T_WTS();

                        Mwts.FWZH = fwzh;
                        Mwts.FC = wxfc;
                        Mwts.WTSH = wtsh;
                        Mwts.cc_xgbz = "1";
                    }
                    else
                    {
                        flag = "Edit";
                    }


                    Mwts.JDGW = DT_wts.JDGW.Trim();
                    Mwts.XXY = DT_wts.XXY.Trim();
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["HJ"].ToString())) 
                    //    Mwts.HJ = 0; 
                    //else 
                    //    Mwts.HJ = decimal.Parse(DT_wts.Rows[i]["HJ"].ToString());
                    Mwts.HJ = DT_wts.HJ;

                    Mwts.DW_CZ = dw_cz;

                    //修理类别
                    switch (xllb)
                    {
                        case "例行保养": xllb = "保养"; break;
                        case "精品装潢": xllb = "装潢"; break;
                        case "保修索赔": xllb = "索赔"; break;
                        case "返修": xllb = "返工"; break;
                        case "强保": xllb = "免保"; break;
                        default: xllb = "小修"; break;
                    }
                    Mwts.XLLB_DM = xllb;

                    Mwts.DZ = dz;
                    Mwts.YB = yb;
                    Mwts.SJH = sjh;
                    Mwts.CPH = cph;
                    Mwts.DPH = dph;
                    Mwts.SCRQ = scrq;
                    Mwts.VSN = vsn;
                    Mwts.FDJH = fdjh;
                    Mwts.BSXH = DT_wts.BSXH.Trim();
                    Mwts.CLYS = clys;
                    Mwts.XH = xh;
                    Mwts.GSBZ = DT_wts.GSBZ;  //工时标准
                    Mwts.GCRQ = lzrq;
                    Mwts.SBRQ = sbrq;
                    Mwts.BXDQ = DT_wts.BXDQ;
                    Mwts.SXR = sxr;
                    Mwts.SXR_XB = DT_wts.SXR_XB;
                    Mwts.ZJHM = DT_wts.ZJHM;
                    Mwts.LCFS = DT_wts.LCFS;  //来厂方式
                    Mwts.SXR_SJH = DT_wts.SXR_SJH;
                    Mwts.ZXG = DT_wts.ZXG;
                    Mwts.GZMS = DT_wts.GZMS;
                    Mwts.CBZD = DT_wts.CBZD;

                    Mwts.HLCBBZ = hlcbbz;                           //换里程表标志
                    Mwts.HLCBRQ = hlcbrq;                           //换里程表日期

                    Mwts.YJWGRQ = DT_wts.YJWGRQ;
                    Mwts.YJWGSJ = DT_wts.YJWGSJ;

                    if (string.IsNullOrEmpty(hblc))
                        Mwts.HBLC = 0;
                    else
                        Mwts.HBLC = int.Parse(hblc);  //换表里程
                    if (string.IsNullOrEmpty(jclc))
                        Mwts.JCLC = 0;
                    else
                        Mwts.JCLC = int.Parse(jclc);  //接车里程
                    if (string.IsNullOrEmpty(xslc))
                        Mwts.XSLC = 0;
                    else
                        Mwts.XSLC = int.Parse(xslc);  //行驶里程
                    Mwts.KHHFYD = DT_wts.KHHFYD;
                    if (string.IsNullOrEmpty(xcbylc) == true)
                        Mwts.XCBYLC = 0;
                    else
                        Mwts.XCBYLC = int.Parse(xcbylc);//下次保养里程

                    Mwts.XCBYRQ = DT_wts.XCBYRQ;
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["CCLC"].ToString())) Mwts.CCLC = 0; else Mwts.CCLC = int.Parse(DT_wts.Rows[i]["CCLC"].ToString());
                    Mwts.CCLC = DT_wts.CCLC;
                    Mwts.BGFS = DT_wts.BGFS;
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["BGF"].ToString())) Mwts.BGF = 0; else Mwts.BGF = decimal.Parse(DT_wts.Rows[i]["BGF"].ToString());
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["SGF"].ToString())) Mwts.SGF = 0; else Mwts.SGF = decimal.Parse(DT_wts.Rows[i]["SGF"].ToString());
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["GJFY"].ToString())) Mwts.GJFY = 0; else Mwts.GJFY = decimal.Parse(DT_wts.Rows[i]["GJFY"].ToString());
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["GFYH"].ToString())) Mwts.GFYH = 0; else Mwts.GFYH = decimal.Parse(DT_wts.Rows[i]["GFYH"].ToString());
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["CLYH"].ToString())) Mwts.CLYH = 0; else Mwts.CLYH = decimal.Parse(DT_wts.Rows[i]["CLYH"].ToString());
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["GSDJ"].ToString())) Mwts.GSDJ = 0; else Mwts.GSDJ = decimal.Parse(DT_wts.Rows[i]["GSDJ"].ToString());
                    Mwts.BGF = DT_wts.BGF;
                    Mwts.SGF = DT_wts.SGF;
                    Mwts.GJFY = DT_wts.GJFY;
                    Mwts.GFYH = DT_wts.GFYH;
                    Mwts.CLYH = DT_wts.CLYH;
                    Mwts.GSDJ = DT_wts.GSDJ;

                    Mwts.JFSX = DT_wts.JFSX;
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["WJGF"].ToString())) Mwts.WJGF = 0; else Mwts.WJGF = decimal.Parse(DT_wts.Rows[i]["WJGF"].ToString());
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["JCF"].ToString())) Mwts.JCF = 0; else Mwts.JCF = decimal.Parse(DT_wts.Rows[i]["JCF"].ToString());
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["YSGF"].ToString())) Mwts.YSGF = 0; else Mwts.YSGF = decimal.Parse(DT_wts.Rows[i]["YSGF"].ToString());
                    //if (string.IsNullOrEmpty(DT_wts.Rows[i]["YSCL"].ToString())) Mwts.YSCL = 0; else Mwts.YSCL = decimal.Parse(DT_wts.Rows[i]["YSCL"].ToString());
                    Mwts.WJGF = DT_wts.WJGF;
                    Mwts.JCF = DT_wts.JCF;
                    Mwts.YSGF = DT_wts.YSGF;
                    Mwts.YSCL = DT_wts.YSCL;

                    Mwts.CK = DT_wts.CK;
                    Mwts.SYRL = DT_wts.SYRL;
                    Mwts.JZRQ = jzrq;       //修理日期
                    Mwts.JZSJ = jzsj;
                    Mwts.KDR = DT_wts.KDR;    //开单人
                    Mwts.KDRQ = kdrq;
                    Mwts.KDSJ = kdsj;
                    Mwts.KDWCRQ = DT_wts.KDWCRQ;
                    Mwts.KDWCSJ = DT_wts.KDWCSJ;
                    Mwts.PGR = DT_wts.PGR;
                    Mwts.PGRQ = DT_wts.PGRQ;
                    Mwts.PGSJ = DT_wts.PGSJ;
                    Mwts.KGRQ = DT_wts.KGRQ;
                    Mwts.KGSJ = DT_wts.KGSJ;
                    Mwts.WGRQ = DT_wts.WGRQ;
                    Mwts.WGSJ = DT_wts.WGSJ;
                    Mwts.WGSCR = DT_wts.WGSCR;
                    Mwts.WGSCRQ = DT_wts.WGSCRQ;
                    Mwts.WGSCSJ = DT_wts.WGSCSJ;
                    Mwts.JSR = DT_wts.JSR;
                    Mwts.JSRQ = DT_wts.JSRQ;
                    Mwts.JSSJ = DT_wts.JSSJ;
                    Mwts.JCRQ = DT_wts.JCRQ;
                    Mwts.JCSJ = DT_wts.JCSJ;

                    Mwts.CP_DM = DT_wts.CP_DM;
                    Mwts.SCPCH = DT_wts.SCPCH;
                    Mwts.SXR_DWDH = DT_wts.SXR_DWDH;
                    Mwts.SXR_JTDH = DT_wts.SXR_JTDH;
                    Mwts.CX = DT_wts.CX;
                    Mwts.DWDH = DT_wts.DWDH;
                    Mwts.JTDH = DT_wts.JTDH;
                    Mwts.LZRQ = DT_wts.LZRQ;

                    if (spfc == "")
                        Mwts.SHSCBZ = "1";
                    else
                        Mwts.SHSCBZ = "9";
                    Mwts.SPJDBZ = spjdbz; //索赔鉴定标志
                    Mwts.old_sqdh = "";
                    Mwts.wxscbz = "1";  //标记此单是从维修系统上传的
                    if (flag == "New")
                    {
                        msg = Twts.Add_Rtmsg(Mwts, SaveWxxm(DT_wts.xmList, fwzh, wtsh), SaveCl(DT_wts.clList, fwzh, wtsh), SaveFj(DT_wts.fjList, fwzh, wtsh));
                    }
                    else
                    {
                        msg = Twts.Update(Mwts, SaveWxxm(DT_wts.xmList, fwzh, wtsh), SaveCl(DT_wts.clList, fwzh, wtsh), SaveFj(DT_wts.fjList, fwzh, wtsh));
                    }

                    //上传成功
                    if (msg == "")
                    {
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", "success");
                        resultList.Add(resultDict);
                        //succeed = succeed + wtsh + "/";
                        //num = num + 1;

                        #region 更新车辆信息
                        if ((sqwxycscbz != "1" && spfc == "") || (xh_clxx == ""))
                        {
                            try
                            {
                                if (lzrq != "")
                                {
                                    mclxx.yhmc = dw_cz;
                                    mclxx.dz = dz;
                                    mclxx.yhdh = sjh;
                                    mclxx.yb = yb;
                                    mclxx.cph = cph;

                                    mclxx.lxr = sxr;
                                    mclxx.lxrdh = Mwts.SXR_SJH;
                                    if (lzrq_clxx == "")
                                        mclxx.lzrq = lzrq;
                                }

                                mclxx.clys = clys;
                                //换表里程标志
                                if (hlcbbz == true)
                                {
                                    mclxx.hlcbxslc = int.Parse(xslc);
                                    mclxx.hlcbrq = hlcbrq;
                                }
                                if (xh_clxx == "")
                                    mclxx.xh = xh;

                                Tclxx.Update(mclxx);
                            }
                            catch
                            {
                            }
                        }
                        #endregion
                    }
                    //上传失败
                    else
                    {
                        errmsg = msg;
                        resultDict.Add("wtsh", wtsh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                    }
                }
                catch (Exception ex)
                {
                    errmsg = ex.Message.Replace("\r\n", "");
                    resultDict.Add("wtsh", wtsh);
                    resultDict.Add("errmsg", errmsg);
                    resultList.Add(resultDict);
                    continue;
                }
            }

            Msg = "success";
            return resultList;

        }
        #endregion

        #region 上传保养单
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> importbyd(List<input_sbd> inputList, ref string Msg)
        {
            if (inputList.Count == 0)
            {
                Msg = "没有保养单数据";
                return null;
            }
            SIS.Model.sbd Msbd = new SIS.Model.sbd();
            SIS.BLL.sbd Tsbd = new SIS.BLL.sbd();

            SIS.Model.fwzk Mfwzk = new SIS.Model.fwzk();
            SIS.BLL.fwzk Tfwzk = new SIS.BLL.fwzk();

            SIS.BLL.xhk b_xhk = new SIS.BLL.xhk();
            SIS.Model.xhk Mxhk = new SIS.Model.xhk();

            SIS.BLL.clxx Tclxx = new SIS.BLL.clxx();
            SIS.Model.clxx Mclxx = new SIS.Model.clxx();

            SIS.BLL.jsd Bjsd = new SIS.BLL.jsd();
            SIS.Model.jsd Mjsd = new SIS.Model.jsd();

            SIS.BLL.fwhd Bfwhd = new SIS.BLL.fwhd();

            DataSet sbd_ds = new DataSet();

            int num = 0;//成功条数
            string succeed = "*", succeednew = "^", lost = "#", errmsg = "$", Memo = "";

            decimal sbf = 0, sbclf = 0; //首保工时费，首保材料费

            string flag = "New";
            string ppFlag = "";
            string cx, byrq, lzrq, scrq, srrq, vin, vsn, fwzh, spfc, wxfc, bycs, zfbz, xh, fdjh, yhmc, yhdh, dz, yb, lxr, lzrq_clxx, xh_xhk, xh_clxx, byrq_clxx, sprq_clxx, thrq, pdibz, pdism;
            string sqdh = "", wx_sqdh = "", sh_sqdh = "", msg = "", jtbz = "", pdiycscbz;
            string jdgw = "", zxg = "", sbjhm = "", jcrq = "";
            int bslc, hblc, bylc_clxx, splc_clxx;
            int zsbycs = 0;
            Hashtable ht = new Hashtable();
            decimal gsfdr, clfdr, byjedr;
            string wsqfch = "";
            bool wsqfc_flag = false;

            IList<SIS.Model.sbd_pdi> Isbdpdi = null;
            List<Dictionary<string, string>> resultList = new List<Dictionary<string, string>>();
            Dictionary<string, string> resultDict = null;

            foreach (input_sbd _sbd in inputList)
            {
                resultDict = new Dictionary<string, string>();
                Isbdpdi = new List<SIS.Model.sbd_pdi>();
                try
                {
                    Memo = "";
                    fwzh = _sbd.fwzh.ToString().Trim();        //服务站号
                    wx_sqdh = _sbd.sqdh.ToString().Trim();     //维修申请单号
                    sh_sqdh = _sbd.sh_sqdh.ToString().Trim();  //售后申请单号
                    wxfc = _sbd.sjfc.ToString().Trim();        //实际分厂号
                    lzrq = _sbd.lzrq.ToString().Trim();        //开票日期
                    byrq = _sbd.byrq.ToString().Trim();        //保养日期
                    scrq = _sbd.scrq.ToString().Trim();        //生产日期
                    srrq = _sbd.srrq.ToString().Trim();        //输入日期
                    bycs = _sbd.bycs.ToString().Trim();        //保养类别
                    vsn = _sbd.vsn.ToString().Trim().ToUpper();//VSN
                    vin = _sbd.dph.ToString().Trim().ToUpper();//VIN
                    xh = _sbd.xh.ToString().Trim().ToUpper();  //车型
                    fdjh = _sbd.fdjh.ToString().Trim().ToUpper();//发动机号
                    yhmc = _sbd.yhmc.ToString().Trim();        //用户名称
                    yhdh = _sbd.yhdh.ToString().Trim();        //用户电话
                    dz =  _sbd.dz.ToString().Trim();            //地址
                    yb = _sbd.yb.ToString().Trim();            //邮编
                    lxr = _sbd.lxr.ToString().Trim();          //联系人
                    zfbz = _sbd.zfbz.ToString().Trim();        //自费标志
                    pdibz = _sbd.pdibz.ToString().Trim();      //pdi标志
                    pdism = _sbd.memo.ToString().Trim();       //pdi检查说明
                    jdgw = _sbd.jdgw.ToString().Trim();        //接待顾问
                    zxg = _sbd.zxg.ToString().Trim();          //主修工
                    sbjhm = _sbd.sbjhm.ToString().Trim();      //强保激活码
                    jcrq = _sbd.jcrq.Trim();                   //接车日期

                    pdiycscbz = "";
                    spfc = "";
                    //判断是什么品牌服务站
                    if (fwzh.Substring(0, 1) == SIS.Model.GlobalConst.topOfBaoJun)
                    {
                        ppFlag = SIS.Model.GlobalConst.BaoJun;
                    }
                    else
                    {
                        ppFlag = SIS.Model.GlobalConst.WuLing;
                    }

                    #region 必填判断

                    //VIN码不能为空
                    if (vin == "")
                    {
                        errmsg = "VIN码不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //用户名称不能为空
                    if (yhmc == "")
                    {
                        errmsg = "用户名称不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //用户电话不能为空
                    if (yhdh == "")
                    {
                        errmsg = "用户电话不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //地址不能为空
                    if (dz == "")
                    {
                        errmsg = "地址不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //联系人不能为空
                    if (lxr == "")
                    {
                        errmsg = "联系人不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //生产日期不能为空
                    if (scrq == "")
                    {
                        errmsg = "生产日期不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //保养日期不能为空
                    if (byrq == "")
                    {
                        errmsg = "保养日期不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    #endregion

                    #region 里程和日期逻辑判断

                    //表示里程是否为整数
                    if (SIS.Common.PageValidate.IsNumber(_sbd.bslc.ToString().Trim()) == false)
                    {
                        errmsg = "无效的表示里程，必须为整数";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    else
                    {
                        bslc = int.Parse(_sbd.bslc.ToString().Trim());
                    }
                    //换表里程是否为整数
                    if (SIS.Common.PageValidate.IsNumber(_sbd.hblc.ToString().Trim()) == false)
                    {
                        errmsg = "无效的换表里程，必须为整数";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    else
                    {
                        hblc = int.Parse(_sbd.hblc.ToString().Trim());
                    }
                    //分厂判断
                    if (wxfc != "" && PageValidate.IsFCHCode(wxfc) == false)
                    {
                        errmsg = "无效的分厂号，必须为数字或字母";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //日期逻辑判断
                    msg = byd_chkrq(lzrq, scrq, byrq, srrq, bycs);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    #endregion

                    #region 服务站-批次是否结算-服务站和车对应-保养类别-分厂提交标志状态的判断
                    //判断保养类别
                    if (PageValidate.IsNumber(bycs) == false)
                    {
                        errmsg = "保养类别格式不正确";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    wsqfc_flag = false;
                    if (wxfc != "")
                    {
                        if (PageValidate.IsNumber(wxfc) == true && int.Parse(wxfc) >= GlobalConst.unAuthorizedFcStart && int.Parse(wxfc) <= GlobalConst.unAuthorizedFcEnd)
                        {
                            spfc = "";
                            wsqfc_flag = true;
                        }
                        else
                        {
                            spfc = wxfc;
                            wsqfc_flag = false;
                        }

                    }
                    //判断服务站是否存在
                    Mfwzk = Tfwzk.GetModel(fwzh, spfc);
                    if (Mfwzk == null)
                    {
                        errmsg = "服务站号在售后索赔系统中不存在";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断是否锁定
                    if (IsLocked.IsLockfwz(Mfwzk, byrq) == true)
                    {
                        errmsg = "服务站已解约，不能进行该操作！";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断服务站是否开通了上传功能
                    if (Mfwzk.wxscbz.Trim() != "1")
                    {
                        errmsg = "服务站还没有开通上传功能";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断未授权网点是否允许上传单据
                    if (wsqfc_flag == true)
                    {
                        wsqfch = Mfwzk.ktwsqfch.Trim();
                        if (wsqfch.IndexOf(wxfc) < 0)
                        {
                            errmsg = "网点" + wxfc + "未授权";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }


                    //判断该批次是否已经结算，若已经结算，不能提交
                    Mjsd = Bjsd.GetModel(fwzh + byrq.Substring(0, 6));
                    if (Mjsd != null)
                    {
                        if (Mjsd.jsrq.Trim() != "")
                        {
                            errmsg = byrq.Substring(0, 6) + "这个批次已经结算，不能再上传单据";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }

                    //判断服务站和车是否对应
                    msg = b_xhk.IfCarInFwzh(fwzh, spfc, vsn, byrq);
                    if (string.IsNullOrEmpty(msg.Trim()) == false)
                    {
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    #endregion

                    #region 车辆信息是否一致

                    if (vsn.Length < 4)
                    {
                        errmsg = "VSN小于4位";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (vin.Length != 17)
                    {
                        errmsg = "VIN码不正确";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (SIS.Common.PageValidate.IsVINCode(vin) == false)
                    {
                        errmsg = "VIN码格式不正确";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    Mclxx = Tclxx.GetModel(vin);

                    if (Mclxx == null)
                    {
                        errmsg = "车辆库中不存在该车辆信息";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (Mclxx.spbz.Trim() != "1")
                    {
                        errmsg = "此车为不索赔车辆不能上传";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (Mclxx.vsn.Trim().ToUpper() != vsn)
                    {
                        errmsg = "VSN码与车辆库中的VSN码不一致";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //----------------------------------判断车型是否一致
                    Mxhk = b_xhk.GetModel(vsn.Substring(0, 4));
                    if (Mxhk == null)
                    {
                        errmsg = "VSN码对应的品种代码不能找到";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    else
                    {
                        xh_xhk = Mxhk.xhbh.Trim().ToUpper();
                        if (xh_xhk != xh)
                        {
                            errmsg = "车型与品种代码中的车型不一致";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                        xh_clxx = Mclxx.xh.Trim().ToUpper();
                        if (xh_xhk != xh_clxx)
                        {
                            xh_clxx = "";
                        }
                    }

                    //----------------------------------判断发动机是否一致
                    if (Mclxx.fdjh.Trim().ToUpper() != fdjh)
                    {
                        errmsg = "发动机号与车辆库中的发动机号不一致";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (Mclxx.scrq.Trim() != scrq)
                    {
                        errmsg = "生产日期与车辆库中生产日期不一致";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    lzrq_clxx = Mclxx.lzrq.Trim();
                    if (bycs == "1" && lzrq_clxx != "" && (int.Parse(byrq) <= int.Parse(lzrq_clxx)))
                    {
                        //--PDI延迟提交时，不需要判断开票日期是否一致，提交时不需要更新车辆信息
                        pdiycscbz = "1";
                    }
                    else
                    {
                        if (lzrq != lzrq_clxx && lzrq_clxx != "")
                        {
                            errmsg = "开票日期与车辆库中开票日期不一致";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }
                    bylc_clxx = Mclxx.bylc;
                    splc_clxx = Mclxx.splc;
                    byrq_clxx = Mclxx.byrq.Trim();
                    sprq_clxx = Mclxx.sprq.Trim();

                    //chk_sbd中判断
                    #endregion

                    #region 判断赠送保养类型是否正确
                    //----------------------------------判断保养类型是否正确
                    if (int.Parse(bycs) > 2)
                    {
                        zsbycs = Tclxx.getZsbycs(vin, vsn.Substring(0, 4), scrq, lzrq, byrq);
                        if (zsbycs == 0)
                        {
                            errmsg = "保养类别不正确";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                        else
                        {
                            // 赠送保养从bycs=3开始
                            if (int.Parse(bycs) > (zsbycs + 2))
                            {
                                errmsg = "保养类别不正确！";
                                resultDict.Add("sqdh", wx_sqdh);
                                resultDict.Add("errmsg", errmsg);
                                resultList.Add(resultDict);
                                continue;
                            }
                        }
                    }

                    #endregion

                    if (sh_sqdh != "")
                    {
                        Msbd = Tsbd.GetModel(fwzh, sh_sqdh);
                        if (Msbd == null)
                        {
                            errmsg = "售后索赔系统中保养单号" + sh_sqdh + "不存在";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                        else
                        {
                            //状态为“被返回”或“待提交”
                            if (Msbd.zt.Trim() == "8" || Msbd.zt.Trim() == "9")
                            {
                                flag = "Edit";
                            }
                            else
                            {
                                errmsg = "售后索赔系统中保养单号" + sh_sqdh + "已上传到厂家，不能再次上传";
                                resultDict.Add("sqdh", wx_sqdh);
                                resultDict.Add("errmsg", errmsg);
                                resultList.Add(resultDict);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        //检查单据是否已经上传
                        sbd_ds = Tsbd.GetList(" fwzh='" + fwzh + "' and fc='" + wxfc + "' and wxsqdh='" + wx_sqdh + "' and dph='" + vin + "'");
                        if (sbd_ds.Tables[0].Rows.Count == 0)
                        {
                            flag = "New";
                            Msbd = new SIS.Model.sbd();
                        }
                        else
                        {
                            sh_sqdh = sbd_ds.Tables[0].Rows[0]["sqdh"].ToString().Trim();
                            if (sbd_ds.Tables[0].Rows[0]["zt"].ToString().Trim() == "8" || sbd_ds.Tables[0].Rows[0]["zt"].ToString().Trim() == "9")
                            {
                                Msbd = Tsbd.GetModel(fwzh, sh_sqdh);
                                flag = "Edit";
                            }
                            else
                            {
                                resultDict.Add("sqdh", wx_sqdh);
                                resultDict.Add("sqdh_sh", sh_sqdh);
                                resultDict.Add("memo", Memo);
                                resultDict.Add("errmsg", "success");
                                resultList.Add(resultDict);

                                //sqdh = sbd_ds.Tables[0].Rows[0]["sqdh"].ToString().Trim();
                                //succeed = succeed + wx_sqdh + "/";
                                //succeednew = succeednew + sqdh + "|" + Memo + "/";
                                //num = num + 1;
                                continue;
                            }
                        }
                    }

                    //开始赋值
                    Msbd.fwzh = fwzh;
                    Msbd.fc = wxfc;
                    Msbd.srrq = srrq;                   //输入日期
                    Msbd.jlrq = srrq;                   //新建日期
                    Msbd.bycs = int.Parse(bycs);        //保养类别

                    Msbd.fcyxtjbz = "1";                //分厂允许提交标志

                    Msbd.fwzjc = Mfwzk.fwzjc.Trim();    //服务站简称
                    Msbd.swdb = Mfwzk.swdb.Trim();      //服务中心
                    Msbd.xspq = Mfwzk.xspq.Trim();      //销售片区
                    Msbd.fwjlmc = Mfwzk.fwjlmc.Trim();  //服务经理

                    Msbd.yhmc = yhmc;                   //用户名称
                    Msbd.yhdh = yhdh;                   //用户电话
                    Msbd.dz = dz;                       //地址
                    Msbd.yb = yb;                       //邮编
                    Msbd.lxr = lxr;                     //联系人

                    Msbd.xh = xh;                       //车型
                    Msbd.dph = vin;                     //底盘号
                    Msbd.fdjh = fdjh;                   //发动机号
                    Msbd.bsxh = _sbd.bsxh.ToString();   //变速箱号

                    Msbd.yqdh = _sbd.yqdh.ToString();   //油漆编号
                    Msbd.scrq = scrq;                   //生产日期

                    if (bycs != "1")
                    {
                        if (lzrq == "")
                        {
                            errmsg = "开票日期不能为空";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                        if (bslc == 0)
                        {
                            errmsg = "表示里程不能为0";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }

                        Msbd.lzrq = lzrq;         //开票日期
                        Msbd.pdibz = "";          //pdi检查标志
                    }
                    //保养类别为接车检查
                    else
                    {
                        if (lzrq != "")
                        {
                            errmsg = "接车检查时开票日期必须为空";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                        // DMS系统还未升级时，采用原来的判断方式
                        if (_sbd.pdiList == null)
                        {
                            if (ppFlag == SIS.Model.GlobalConst.WuLing)
                            {
                                pdibz = "";
                            }
                            else
                            {
                                if (pdibz != "0" && pdibz != "1")
                                {
                                    errmsg = "接车检查时必须选择PDI检查结果，请选择";
                                    resultDict.Add("sqdh", wx_sqdh);
                                    resultDict.Add("errmsg", errmsg);
                                    resultList.Add(resultDict);
                                    continue;
                                }

                                if (pdibz == "0" && pdism == "")
                                {
                                    errmsg = "PDI检查结果为“不正常”时，必须输入PDI检查说明";
                                    resultDict.Add("sqdh", wx_sqdh);
                                    resultDict.Add("errmsg", errmsg);
                                    resultList.Add(resultDict);
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            // 五菱和宝骏服务站都需要判断
                            if (pdibz != "0" && pdibz != "1")
                            {
                                errmsg = "接车检查时必须选择PDI检查结果，请选择";
                                resultDict.Add("sqdh", wx_sqdh);
                                resultDict.Add("errmsg", errmsg);
                                resultList.Add(resultDict);
                                continue;
                            }
                            if (jcrq == "")
                            {
                                errmsg = "保养类型为“接车检查”时，必须填写接车日期";
                                resultDict.Add("sqdh", wx_sqdh);
                                resultDict.Add("errmsg", errmsg);
                                resultList.Add(resultDict);
                                continue;
                            }
                            //PDI检查不合格时，必须要上传故障项
                            if (pdibz == "0")
                            {
                                #region PDI检查故障项目
                                Isbdpdi = SaveSbdPdi(_sbd.pdiList, fwzh, wx_sqdh, out msg);
                                if (msg != "")
                                {
                                    errmsg = msg;
                                    resultDict.Add("sqdh", wx_sqdh);
                                    resultDict.Add("errmsg", errmsg);
                                    resultList.Add(resultDict);
                                    continue;
                                }
                                if (Isbdpdi.Count == 0)
                                {
                                    errmsg = "PDI检查结果为“不正常”时，必须选择PDI检查故障项";
                                    resultDict.Add("sqdh", wx_sqdh);
                                    resultDict.Add("errmsg", errmsg);
                                    resultList.Add(resultDict);
                                    continue;
                                }
                                #endregion
                            }
                        }

                        Msbd.lzrq = "";
                        Msbd.pdibz = pdibz;                             //pdi检查标志
                    }

                    Msbd.bslc = bslc;                                   //表示里程
                    Msbd.hblc = hblc;                                   //换表里程
                    Msbd.xslc = bslc + hblc;                            //行驶里程

                    Msbd.clyt = _sbd.clyt.ToString().Trim();            //车辆用途
                    Msbd.cph =  _sbd.cph.ToString().Trim();             //车牌号

                    Msbd.byrq = byrq;                                   //保养日期
                    Msbd.memo = pdism;                                  //备注
                    Msbd.vsn = vsn;                                     //VSN码
                    Msbd.jtbz = _sbd.jtbz.ToString();                   //集团标志
                    Msbd.jdgw = jdgw;                                   //接待顾问
                    Msbd.zxg = zxg;                                     //主修工
                    Msbd.sbjhm = sbjhm;                                 //强保激活码
                    Msbd.jcrq = jcrq;                                   //接车日期

                    Msbd.czymc = _sbd.czymc.Trim();                     //操作员名称
                    Msbd.czydm = _sbd.czydm.Trim();                     //操作员代码

                    //取保养单退回日期，新上传的单子没有退回日期为空
                    if (Msbd.shrq == null)
                        thrq = "";
                    else
                    {
                        thrq = Msbd.shrq.Trim();
                    }

                    decimal.TryParse(_sbd.gsf, out gsfdr);
                    decimal.TryParse(_sbd.clf, out clfdr);
                    decimal.TryParse(_sbd.byje, out byjedr);

                    jtbz = "";
                    sbf = 0; sbclf = 0;
                    if (bycs == "0")
                    {
                        Msbd.gsf = 0;
                        Msbd.clf = 0;
                        Msbd.byje = 0;
                    }
                    else
                    {
                        msg = Tsbd.GetByje(fwzh, vsn.Substring(0, 4), vin, int.Parse(bycs), byrq, scrq, lzrq, "", Msbd.jtbz, ref sbf, ref sbclf, ref jtbz);
                        if (string.IsNullOrEmpty(msg))
                        {
                            Msbd.gsf = sbf;
                            Msbd.clf = sbclf;
                            Msbd.byje = sbf + sbclf;
                            Msbd.jtbz = jtbz;
                        }
                        else
                        {
                            Msbd.gsf = 0;
                            Msbd.clf = 0;
                            Msbd.byje = 0;
                        }
                    }

                    if (Decimal.Round(Msbd.byje, 2, MidpointRounding.AwayFromZero) != Decimal.Round(byjedr, 2, MidpointRounding.AwayFromZero))
                    {
                        Memo = "保养金额" + byjedr.ToString() + "与索赔系统计算出来的保养金额" + System.Decimal.Round(Msbd.byje, 2, MidpointRounding.AwayFromZero) + "不一致,原因可能是本地系统基础代码库与售后索赔结算系统的基础代码库不一致!";
                    }

                    if (bycs != "0")
                    {
                        if (int.Parse(bycs) > 2)
                        {
                            ht = Tsbd.CheckZsby(fwzh, "", vin, int.Parse(bycs));
                            if (bool.Parse(ht["okflag"].ToString()) == false)
                            {
                                errmsg = ht["msg"].ToString();
                                resultDict.Add("sqdh", wx_sqdh);
                                resultDict.Add("errmsg", errmsg);
                                resultList.Add(resultDict);
                                continue;
                            }
                            else
                            {
                                if (ht["msg"].ToString().Trim() != "")
                                {
                                    Memo = Memo + "  " + ht["msg"].ToString().Trim();
                                }
                            }
                        }
                        if (Tsbd.IfBy(fwzh, "", vin, int.Parse(bycs)) == true)
                        {
                            if (bycs == "1")
                                errmsg = "该车已做过售前检查";
                            else if (bycs == "2")
                                errmsg = "该车已做过保养1（强保）";
                            else
                                errmsg = "该车已做过保养" + (int.Parse(bycs) - 1).ToString();
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }

                    //自费标志
                    if (bycs == "0")
                    {
                        Msbd.zfbz = "自费";
                    }
                    else if (bycs == "1")
                    {
                        Msbd.zfbz = "免费";
                    }
                    else if (int.Parse(bycs) > 2)
                    {
                        Msbd.zfbz = "免费";
                    }

                    //超保检查
                    cx = "";
                    msg = Tsbd.chk_sbd_Dms(fwzh, vsn.Substring(0, 4), vin, int.Parse(bycs), Msbd.xslc, lzrq, scrq, byrq, bylc_clxx, splc_clxx, byrq_clxx, sprq_clxx, thrq, ppFlag, sbjhm, out cx);
                    if ((msg.Trim() == "贵站尚未授权该车型的索赔业务！") || (msg.Trim() == "该车本次保养其他服务站已做！") || (msg.Trim() == "VSN码对应的品种代码不能找到！") || (msg.IndexOf("PDI检查、保养单") == 0) || (msg.IndexOf("强保激活码") >= 0))
                    {
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    #region 服务活动上传控制判断

                    msg = Bfwhd.chk_fwhd_sckz(vin, cx, Msbd.scrq, Msbd.lzrq, Msbd.xslc, Mxhk.spq, Mxhk.splc, fwzh);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    #endregion
                    Msbd.cx = cx;
                    if (string.IsNullOrEmpty(msg.Trim()) == false)
                    {
                        if (bycs == "2")
                        {
                            Msbd.zfbz = zfbz;
                        }
                    }
                    else
                    {
                        if (bycs == "2")
                        {
                            Msbd.zfbz = zfbz;
                        }
                    }

                    Msbd.shbz = "";
                    Msbd.jsbz = "";

                    Msbd.wxscbz = "1";                  //维修（DMS）上传标志
                    Msbd.wxsqdh = wx_sqdh;              //维修（DMS）申请单号  

                    if (spfc == "")
                    {
                        //总厂提交时操作
                        Msbd.cc_xgbz = "1";
                        if (Msbd.bycs == 0 || Msbd.zfbz.Trim() == "自费")
                        {
                            Msbd.zt = "4";
                            Msbd.jdrq = DateTime.Today.ToString("yyyyMMdd");
                        }
                        else
                        {
                            Msbd.zt = "1";
                            Msbd.jdrq = DateTime.Today.ToString("yyyyMMdd");
                        }
                    }
                    else
                    {
                        Msbd.zt = "9";
                        Msbd.jdrq = "";
                    }

                    try
                    {
                        if (flag == "New")
                        {
                            sqdh = Tsbd.GetMaxSqdh(fwzh, byrq);
                            Msbd.sqdh = sqdh;                   //申请单号
                            Msbd.spyf = sqdh.Substring(0, 6);   //索赔月份

                            for (int k = 0; k < Isbdpdi.Count; k++)
                            {
                                Isbdpdi[k].sqdh = sqdh;
                            }

                            msg = Tsbd.AddWithPDI(Msbd, Isbdpdi);
                        }
                        else
                        {
                            sqdh = sh_sqdh;
                            for (int k = 0; k < Isbdpdi.Count; k++)
                            {
                                Isbdpdi[k].sqdh = sqdh;
                            }

                            msg = Tsbd.UpdateWithPDI(Msbd, Isbdpdi);
                            
                        }

                        if (msg != "")
                        {
                            errmsg = msg;
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }

                        //--------------------------------------------保存成功，返回成功sqdh

                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("sqdh_sh", sqdh);
                        resultDict.Add("memo", Memo);
                        resultDict.Add("errmsg", "success");
                        resultList.Add(resultDict);

                        //succeed = succeed + wx_sqdh + "/";
                        //succeednew = succeednew + sqdh + "|" + Memo + "/";
                        //num = num + 1;

                        //更新车辆信息
                        if ((pdiycscbz != "1" && spfc == "") || xh_clxx == "")
                        {
                            try
                            {
                                //开票日期为空时的车辆,客户信息不更新到“车辆信息”中
                                if (lzrq != "")
                                {
                                    Mclxx.yhmc = yhmc;
                                    Mclxx.dz = dz;
                                    Mclxx.yhdh = yhdh;
                                    Mclxx.yb = yb;
                                    Mclxx.cph = Msbd.cph;
                                    Mclxx.clyt = Msbd.clyt;
                                    Mclxx.lxr = lxr;
                                    if (Mclxx.lzrq.Trim() == "")
                                        Mclxx.lzrq = lzrq;
                                }
                                if (xh_clxx == "")
                                    Mclxx.xh = xh;
                                Mclxx.mile = bslc + hblc;

                                Tclxx.Update(Mclxx);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //--------------------------------------------保存失败，返回失败sqdh，下一个循环
                        errmsg = ex.Message.Replace("\r\n", "");
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    //--------------------------------------------保存失败，返回失败sqdh，下一个循环
                    errmsg = ex.Message.Replace("\r\n", "");
                    resultDict.Add("sqdh", wx_sqdh);
                    resultDict.Add("errmsg", errmsg);
                    resultList.Add(resultDict);
                    continue;
                }
            }

            Msg = "success";
            return resultList;
        }
        #endregion

        #region 索赔单上传
       
        //---------------------------------索赔单导入
        public List<Dictionary<string, string>> importbill(List<inputGzd> inputGzdList, ref string msg)
        {
            if (inputGzdList.Count == 0)
            {
                msg = "没有索赔单数据需要上传";
                return null;
            }

            #region 变量初始化

            //------------------------------------------------
            IList<SIS.Model.gzd> Igzd = new List<SIS.Model.gzd>();
            IList<SIS.Model.gzdgs> Igzdgs = new List<SIS.Model.gzdgs>();
            IList<SIS.Model.gzdcl> Igzdcl = new List<SIS.Model.gzdcl>();

            SIS.BLL.gzd Tgzd = new SIS.BLL.gzd();
            SIS.Model.gzd Mgzd;

            SIS.BLL.fwzk Tfwzk = new SIS.BLL.fwzk();
            SIS.Model.fwzk Mfwzk;

            SIS.BLL.xhk Bxhk = new SIS.BLL.xhk();
            SIS.Model.xhk mxhk;

            SIS.BLL.cx_gsbz Bcx_gsbz = new SIS.BLL.cx_gsbz();
            SIS.Model.cx_gsbz mcx_gsbz;

            SIS.BLL.T_WTS Twts = new SIS.BLL.T_WTS();
            //SIS.Model.T_WTS Mwts;

            SIS.BLL.clxx Bclxx = new SIS.BLL.clxx();
            SIS.Model.clxx mclxx;

            SIS.BLL.jsd Bjsd = new SIS.BLL.jsd();
            SIS.Model.jsd Mjsd;

            SIS.BLL.sbd Bsbd = new SIS.BLL.sbd();
            //SIS.Model.sbd Msbd;

            SIS.BLL.sbyjfkd Bsbyjfkd = new SIS.BLL.sbyjfkd();
            SIS.Model.sbyjfkd Msbyjfkd = new SIS.Model.sbyjfkd();

            SIS.BLL.fwhd Bfwhd = new SIS.BLL.fwhd();

            DataSet gzd_ds = new DataSet();
            DataSet wtsDs = new DataSet();

            //int num = 0;//成功条数
            string errmsg = "$", Smsg = "", Memo = "";
            decimal fwzje, qtfy;
            string gwh, clh;

            string flag = "New";
            string ppFlag = "";
            string fwzh, spfc, wxfc, wtsh, wtsh0, cx, xlrq, xlrq0, vin, vsn, mlkw, xh, fdjh, lzrq, scrq, splb, srrq, yhmc, yhdh, lxr, lxrdh, gzms, cljg, xslc, xslc0, pjxh, hdbh, hdbz, thrq;
            string sqdh = "", wx_sqdh = "", sh_sqdh = "", gsbz = "", csm, server_rq, sqwxycscbz, fwzh0, pdibz, pdism, pdisqdh, pdifwzh;
            string xh_xhk, xh_clxx, lzrq_clxx;
            string wsqfch = "";
            bool wsqfc_flag = false;
            int k = 0, spq_xhk, splc_xhk;
            string pp_xhk = "";

            string jzrq, jzsj;
            string wxysqdh = "";
            string sbyjbz = "";
            string sbyjrq = "";
            string tdcx = "";
            string fwhd_sckzbz = "";
            string spjhm = "";

            DateTime startTime;

            List<Dictionary<string, string>> resultList = new List<Dictionary<string, string>>();
            Dictionary<string, string> resultDict = null;

            #endregion

            //-------------------------------------------------主表循环
            foreach (inputGzd gzd in inputGzdList)
            {
                try
                {
                    resultDict = new Dictionary<string, string>();
                    startTime = DateTime.Now;
                    #region 从dataset中取索赔单信息

                    //-------------------------------------------------主表数据
                    //--------------------------------------------------------*表示必填;X表示可以为空;?表示疑问，及可能性
                    fwzh = gzd.fwzh.Trim();
                    wx_sqdh = gzd.sqdh.Trim();         //维修系统申请单号*
                    sh_sqdh = gzd.sh_sqdh.Trim();      //索赔系统申请单号--索赔单号*
                    wxfc = gzd.sjfc.Trim();            //实际分厂*
                    lzrq = gzd.lzrq.Trim();//开票日期X
                    scrq = gzd.scrq.Trim();//生产日期*？车辆的生产日期吗？
                    srrq = gzd.srrq.Trim();//输入日期*？索赔的制单日期吗？
                    vin = gzd.dph.Trim().ToUpper();//VIN码*
                    vsn = gzd.vsn.Trim().ToUpper();//VSN*
                    xh = gzd.xh.Trim().ToUpper();//车型*(例如:LZW7150ADF)，后面的cx(GP50)是车型平台,车型平台下面是车型
                    fdjh = gzd.fdjh.Trim().ToUpper();//发动机号*
                    splb = gzd.splb.Trim();//索赔类别*？需要提供类别的字典,且说明每一种类别的用途，既什么情况下开哪一种类别的索赔单(已知服务活动需要开“其他”的索赔单)
                    wtsh = gzd.wtsh.Trim();//委托书编号*                
                    yhmc = gzd.yhmc.Trim();//用户名称*?是指车主吗？
                    yhdh = gzd.yhdh.Trim();//用户电话*?是指车主的电话吗？
                    lxr = gzd.lxr.Trim();//联系人*？是指什么联系人经销商、车主的联系人？
                    lxrdh = gzd.sjh.Trim();//联系人手机号*？是指什么联系人经销商、车主的联系人？
                    gzms = gzd.gzms.Trim();//故障描述*？手工输入吗？
                    cljg = gzd.cljg.Trim();//处理结果*？手工输入吗？
                    xlrq = gzd.xlrq.Trim();//修理日期*
                    xslc = gzd.xslc.Trim();//形式里程*

                    qtfy = decimal.Parse(gzd.qtfy.Trim());    //其他费用*？手工输入？
                    fwzje = decimal.Parse(gzd.fwzje.Trim());  //服务站申请金额*？是否为（工时金额+配件金额+其他费用）?

                    fwzh0 = gzd.fwzh0.Trim();//换件服务站号X?如何取值,什么情况下填写此值？
                    wtsh0 = gzd.wtsh0.Trim();//换件委托书号X?如何取值,什么情况下填写此值?
                    xlrq0 = gzd.xlrq0.Trim();//换件日期X?如何取值,什么情况下填写此值?
                    xslc0 = gzd.xslc0.Trim();//换件里程X？如何取值,什么情况下填写此值？

                    pdisqdh = gzd.pdisqdh.Trim();//pdi申请单号X?如何取值,什么情况下填写此值?
                    wxysqdh = gzd.wxysqdh.Trim();//三包维修预申请单X?此处是预申请单单号吗？有预申请单标记的配件、工时时必填，是这样吗?
                    spjhm = gzd.spjhm.Trim();//索赔激活码X?没有此参数，请确认?

                    try
                    {
                        // 开单日期,开单时间
                        jzrq = gzd.jzrq.Trim();
                        jzsj = gzd.jzsj.Trim();
                    }
                    catch
                    {
                        jzrq = "19000101";
                        jzsj = "00:00:00";
                    }

                    #endregion

                    server_rq = DateTime.Now.ToString("yyyyMMdd");
                    sqwxycscbz = "";
                    spfc = "";
                    Memo = "";

                    #region 判断是什么品牌服务站

                    if (fwzh.Substring(0, 1) == SIS.Model.GlobalConst.topOfBaoJun)
                    {
                        ppFlag = SIS.Model.GlobalConst.BaoJun;
                        pdifwzh = gzd.fwzh1.Trim();
                    }
                    else
                    {
                        ppFlag = SIS.Model.GlobalConst.WuLing;
                        pdifwzh = "";
                    }

                    #endregion

                    #region 必填验证
                    if (vin == "")
                    {
                        errmsg = "VIN码不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (yhmc == "")
                    {
                        errmsg = "用户名称不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (yhdh == "")
                    {
                        errmsg = "用户电话不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (fdjh == "")
                    {
                        errmsg = "发动机号不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (lxr == "")
                    {
                        errmsg = "联系人不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (gzms == "")
                    {
                        errmsg = "故障描述不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (cljg == "")
                    {
                        errmsg = "原因分析检查结果不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (scrq == "")
                    {
                        errmsg = "生产日期不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (xlrq == "")
                    {
                        errmsg = "修理日期不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (xslc == "")
                    {
                        errmsg = "行驶里程不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    if (splb == "1")
                    {
                        #region 移动到后面判断
                        /*
                    if (ppFlag == SIS.Model.GlobalConst.WuLing)
                    {
                        //五菱没有PDI
                    }
                    else
                    {
                        if (pdisqdh == "")
                        {
                            errmsg = "售前维修未关联PDI！";
                            lost = lost + wx_sqdh + "|" + errmsg + "/";
                            continue;
                        }
                        if (pdifwzh == "")
                        {
                            errmsg = "PDI服务站号不能为空！";
                            lost = lost + wx_sqdh + "|" + errmsg + "/";
                            continue;
                        }
                    }
                    */
                        #endregion
                    }
                    else if (splb == "2")
                    {
                        if (fwzh0 == "")
                        {
                            errmsg = "配件索赔时，购件站号不能为空";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                        if (wtsh0 == "")
                        {
                            errmsg = "配件索赔时，购件单号不能为空";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }
                    else
                    {
                    }

                    #endregion

                    #region 验证 1、里程 2、验证vsn 3、日期 4、服务站是否存在 5、服务站与车对应 6、索赔类别

                    //里程是否正确
                    if (PageValidate.IsNumber(xslc) == false)
                    {
                        errmsg = "无效的行驶里程，必须为整数";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (PageValidate.IsNumber(xslc0) == false)
                    {
                        errmsg = "无效的购件里程，必须为整数";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //分厂判断
                    if (wxfc != "" && PageValidate.IsFCHCode(wxfc) == false)
                    {
                        errmsg = "无效的分厂号，必须为数字或字母";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //无效的车辆生产日期
                    if (scrq != "")
                    {
                        if (scrq.Length != 8 || scrq.CompareTo("19700101") < 0 || scrq.CompareTo("20990101") > 0)
                        {
                            errmsg = "无效的车辆生产日期";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }
                    //无效的车辆开票日期
                    if (lzrq != "")
                    {
                        if (lzrq.Length != 8 || lzrq.CompareTo("19700101") < 0 || lzrq.CompareTo("20990101") > 0)
                        {
                            errmsg = "无效的车辆开票日期";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }
                    //无效的车辆修理日期
                    if (xlrq != "")
                    {
                        if (xlrq.Length != 8 || xlrq.CompareTo("19700101") < 0 || xlrq.CompareTo("20990101") > 0 || xlrq.CompareTo(server_rq) > 0)
                        {
                            errmsg = "无效的车辆修理日期";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }

                    //判断日期逻辑
                    msg = spd_chkrq(lzrq, scrq, xlrq, srrq, splb);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //索赔类别是否正确
                    if (splb != "" && splb != "0" && splb != "1" && splb != "2" && splb != "4" && splb != "5")
                    {
                        errmsg = "索赔类别不正确";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //验证VSN
                    if (vsn.Length < 4)
                    {
                        errmsg = "VSN小于4位";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //VSN码是否正确
                    mxhk = Bxhk.GetModel(vsn.Substring(0, 4));
                    if (mxhk == null)
                    {
                        errmsg = "找不到VSN码对应的品种代码";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //取车型平台/工时标准/配件型号
                    pjxh = ""; gsbz = ""; csm = "";
                    cx = Bxhk.Get_CxPjxhGsbz(vsn.Substring(0, 4), scrq, xlrq, out pjxh, out gsbz, out csm).ToUpper();
                    pjxh = pjxh.ToUpper();

                    mlkw = mxhk.mlkw.Trim();
                    xh_xhk = mxhk.xhbh.Trim().ToUpper();
                    spq_xhk = mxhk.spq;
                    splc_xhk = mxhk.splc;
                    pp_xhk = mxhk.pp.Trim();

                    //查找工时标准
                    mcx_gsbz = Bcx_gsbz.GetModel(cx, mlkw, "1"); //上传的单据，都取新的工时标准
                    if (mcx_gsbz == null)
                    {
                        errmsg = "找不到VSN码对应的车系-工时标准";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    gsbz = mcx_gsbz.gsbz.Trim();

                    wsqfc_flag = false;
                    if (wxfc != "")
                    {
                        if (PageValidate.IsNumber(wxfc) == true && int.Parse(wxfc) >= GlobalConst.unAuthorizedFcStart && int.Parse(wxfc) <= GlobalConst.unAuthorizedFcEnd)
                        {
                            spfc = "";
                            wsqfc_flag = true;
                        }
                        else
                        {
                            spfc = wxfc;
                            wsqfc_flag = false;
                        }
                    }

                    //判断服务号
                    Mfwzk = Tfwzk.GetModel(fwzh, spfc);
                    if (Mfwzk == null)
                    {
                        errmsg = "服务站号在索赔结算系统中不存在";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断是否锁定
                    if (IsLocked.IsLockfwz(Mfwzk, xlrq) == true)
                    {
                        errmsg = "服务站已解约，不能进行该操作！";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断服务站是否开通了上传功能
                    if (Mfwzk.wxscbz.Trim() != "1")
                    {
                        errmsg = "服务站还没有开通上传功能";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断未授权网点是否允许上传单据
                    if (wsqfc_flag == true)
                    {
                        wsqfch = Mfwzk.ktwsqfch.Trim();
                        if (wsqfch.IndexOf(wxfc) < 0)
                        {
                            errmsg = "网点" + wxfc + "未授权";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }

                    //sbyjbz = Mfwzk.sbyjbz.Trim();   // 是否开通三包预警功能标志
                    sbyjrq = Mfwzk.sbyjrq.Trim();   // 三包预警启用日期
                    tdcx = Mfwzk.tdcx.Trim();       // 特定车型

                    //判断服务站和车是否对应
                    msg = Bxhk.IfCarInFwzh(fwzh, spfc, vsn, xlrq);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    #endregion

                    #region 索赔单中车辆信息与车辆信息中信息比较
                    if (SIS.Common.PageValidate.IsVINCode(vin) == false)
                    {
                        errmsg = "VIN码格式不正确";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //5:-------------------------------------------------车辆库中找不到该车，车型与车辆库中的车型不一致！
                    mclxx = Bclxx.GetModel(vin);
                    if (mclxx == null)
                    {
                        errmsg = "车辆库中不存在该车辆信息";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //6:-------------------------------------------------此车为不索赔车辆！
                    if (mclxx.spbz.Trim() != "1")
                    {
                        errmsg = "此车为不索赔车辆不能上传";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //7:-------------------------------------------------车型与车辆库中的车型不一致！
                    if (xh_xhk != xh)
                    {
                        errmsg = "车型与品种代码中的车型不一致";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    xh_clxx = mclxx.xh.Trim().ToUpper();
                    if (xh_xhk != xh_clxx)
                    {
                        xh_clxx = "";
                    }
                    //8:-------------------------------------------------发动机号与车辆库中的发动机号不一致！
                    if (mclxx.fdjh.Trim().ToUpper() != fdjh)
                    {
                        errmsg = "发动机号与车辆库中的发动机号不一致";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //9:-------------------------------------------------VSN码与车辆库中的VSN码不一致！
                    if (mclxx.vsn.Trim().ToUpper() != vsn)
                    {
                        errmsg = "VSN码与车辆库中的VSN码不一致";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //10:-------------------------------------------------此次索赔里程小于上次索赔里程/保养里程
                    if (((int.Parse(xslc) <= mclxx.splc) && (xlrq.CompareTo(mclxx.sprq.Trim()) > 0)) || ((int.Parse(xslc) < mclxx.splc) && (xlrq.CompareTo(mclxx.sprq.Trim()) == 0)) || ((int.Parse(xslc) <= mclxx.bylc) && (xlrq.CompareTo(mclxx.byrq.Trim()) > 0)) || ((int.Parse(xslc) < mclxx.bylc) && (xlrq.CompareTo(mclxx.byrq.Trim()) == 0)))
                    {
                        errmsg = "此次索赔里程小于上次索赔里程或保养里程";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //11:-------------------------------------------------开票日期与车辆库中的开票日期不一致
                    lzrq_clxx = mclxx.lzrq.Trim();
                    if ((splb == "1" || splb == "4") && (lzrq_clxx != "") && (lzrq_clxx != "______") && (int.Parse(xlrq) <= int.Parse(lzrq_clxx)))
                    {
                        //--售前维修索赔单后来提交时，不需要判断开票日期是否一致，提交时不需要更新车辆信息
                        sqwxycscbz = "1";
                    }
                    else
                    {
                        if ((lzrq != lzrq_clxx) && (lzrq_clxx != "") && (lzrq_clxx != "______"))
                        {
                            errmsg = "开票日期与车辆库中的开票日期不一致";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }
                    //12:-------------------------------------------------生产日期与车辆库中的生产日期不一致
                    if (mclxx.scrq.Trim() != scrq)
                    {
                        errmsg = "生产日期与车辆库中的生产日期不一致";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }


                    #endregion

                    #region 判断该批次是否已结算

                    Mjsd = Bjsd.GetModel(fwzh + xlrq.Substring(0, 6));
                    if (Mjsd != null)
                    {
                        if (Mjsd.jsrq.Trim() != "")
                        {
                            errmsg = xlrq.Substring(0, 6) + "这个批次已经结算";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }
                    #endregion

                    #region 售前维修判断
                    if (splb == "1")
                    {
                        pdisqdh = "";
                        pdibz = "";
                        pdism = "";
                        pdifwzh = "";
                        /*
                        if (ppFlag == SIS.Model.GlobalConst.WuLing)
                        {
                            pdisqdh = "";
                            pdibz = "";
                            pdism = "";
                            pdifwzh = "";
                        }
                        else
                        {
                            // 宝骏品牌车型需要检查PDI，特定车型不需要检查
                            if (pp_xhk == SIS.Model.GlobalConst.BaoJun)
                            {
                                if (pdisqdh == "")
                                {
                                    errmsg = "售前维修未关联PDI！";
                                    lost = lost + wx_sqdh + "|" + errmsg + "/";
                                    continue;
                                }
                                if (pdifwzh == "")
                                {
                                    errmsg = "PDI服务站号不能为空！";
                                    lost = lost + wx_sqdh + "|" + errmsg + "/";
                                    continue;
                                }

                                Msbd = Bsbd.GetModel(pdifwzh, pdisqdh);
                                if (Msbd != null)
                                {
                                    if (vin != Msbd.dph.Trim().ToUpper() || Msbd.bycs.ToString() != "1")
                                    {
                                        errmsg = "在索赔结算系统中，与索赔单关联的PDI信息不符合要求";
                                        lost = lost + wx_sqdh + "|" + errmsg + "/";
                                        continue;
                                    }
                                    if (Msbd.zt.Trim() != "1" && Msbd.zt.Trim() != "2" && Msbd.zt.Trim() != "3")
                                    {
                                        errmsg = "在索赔结算系统中，与索赔单关联的PDI未上传";
                                        lost = lost + wx_sqdh + "|" + errmsg + "/";
                                        continue;
                                    }

                                    pdibz = Msbd.pdibz.Trim();
                                    pdism = Msbd.memo.Trim();
                                }
                                else
                                {
                                    errmsg = "在索赔结算系统中，找不到与索赔单关联的PDI";
                                    lost = lost + wx_sqdh + "|" + errmsg + "/";
                                    continue;
                                }
                            }
                            else
                            {
                                pdisqdh = "";
                                pdibz = "";
                                pdism = "";
                                pdifwzh = "";
                            }
                        }
                        */
                    }
                    else
                    {
                        pdisqdh = "";
                        pdibz = "";
                        pdism = "";
                        pdifwzh = "";
                    }
                    #endregion

                    #region 配件索赔判断
                    if (splb == "2")
                    {
                        wtsDs = Twts.GetList(" FWZH='" + fwzh0 + "' and WTSH='" + wtsh0 + "' and DPH='" + vin + "'");
                        if (wtsDs.Tables[0].Rows.Count == 0)
                        {
                            errmsg = "索赔结算系统中查找不到该车对应的购件信息，请检查购件站号和购件单号输入是否有误";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                        else
                        {
                            xlrq0 = wtsDs.Tables[0].Rows[0]["JZRQ"].ToString().Trim();
                            xslc0 = wtsDs.Tables[0].Rows[0]["XSLC"].ToString().Trim();

                            if (int.Parse(xslc0) > int.Parse(xslc))
                            {
                                errmsg = "购件里程大于当前行驶里程，请检查行驶里程输入是否有误！";
                                resultDict.Add("sqdh", wx_sqdh);
                                resultDict.Add("errmsg", errmsg);
                                resultList.Add(resultDict);
                                continue;
                            }
                        }
                    }
                    #endregion

                    if (string.IsNullOrEmpty(sh_sqdh) == false)
                    {
                        Mgzd = Tgzd.GetModel(fwzh, sh_sqdh);
                        if (Mgzd == null)
                        {
                            errmsg = "上传失败，售后索赔系统中索赔单号" + sh_sqdh + "不存在";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                        else
                        {
                            if (Mgzd.zt.Trim() == "8" || Mgzd.zt.Trim() == "9")
                            {
                                flag = "Edit";
                            }
                            else
                            {
                                errmsg = "上传失败，售后索赔系统中索赔单号" + sh_sqdh + "状态不是【被返回】或【待提交】";
                                resultDict.Add("sqdh", wx_sqdh);
                                resultDict.Add("errmsg", errmsg);
                                resultList.Add(resultDict);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        gzd_ds = Tgzd.GetList(" dph='" + vin + "' and fwzh='" + fwzh + "' and wxsqdh='" + wx_sqdh + "' and fc='" + wxfc + "' and wtsh='" + wtsh + "'");
                        if (gzd_ds.Tables[0].Rows.Count == 0)
                        {
                            flag = "New";
                            Mgzd = new SIS.Model.gzd();
                        }
                        else
                        {
                            //--------------------------------------------
                            if (gzd_ds.Tables[0].Rows[0]["zt"].ToString().Trim() == "8" || gzd_ds.Tables[0].Rows[0]["zt"].ToString().Trim() == "9")
                            {
                                sh_sqdh = gzd_ds.Tables[0].Rows[0]["sqdh"].ToString().Trim();
                                Mgzd = Tgzd.GetModel(fwzh, sh_sqdh);
                                flag = "Edit";
                            }
                            else
                            {
                                sqdh = gzd_ds.Tables[0].Rows[0]["sqdh"].ToString().Trim();
                                resultDict.Add("sqdh", wx_sqdh);
                                resultDict.Add("sqdh_sh", sqdh);
                                resultDict.Add("errmsg", "success");
                                resultDict.Add("memo", Memo);
                                resultList.Add(resultDict);

                                //succeed = succeed + wx_sqdh + "/";
                                //succeednew = succeednew + sqdh + "|" + Memo + "/";
                                //num = num + 1;
                                continue;
                            }
                        }
                    }

                    #region 索赔单信息赋值

                    Mgzd.fwzh = fwzh;
                    Mgzd.fc = wxfc;
                    Mgzd.wtsh = wtsh;

                    Mgzd.fcyxtjbz = "1";                          //分厂允许提交标志
                    Mgzd.srrq = srrq;                             //输入日期
                    Mgzd.jlrq = srrq;                             //新建日期
                    Mgzd.fwzjc = Mfwzk.fwzjc.Trim();              //简称 
                    Mgzd.swdb = Mfwzk.swdb.Trim();                //服务中心
                    Mgzd.xspq = Mfwzk.xspq.Trim();                //销售片区
                    Mgzd.fwjlmc = Mfwzk.fwjlmc.Trim();            //服务经理
                    Mgzd.yhmc = yhmc;                             //用户姓名
                    Mgzd.yhdh = yhdh;                             //用户电话
                    Mgzd.dz = gzd.dz.Trim();                      //地址
                    Mgzd.yb = gzd.yb.Trim();                      //邮编
                    Mgzd.lxr = lxr;                               //联系人
                    Mgzd.lxrdh = lxrdh;                           //联系人电话

                    Mgzd.xh = xh;                                 //型号
                    Mgzd.dph = vin;                               //底盘号

                    Mgzd.fdjh = fdjh;                             //发动机号
                    Mgzd.bsxh = gzd.bsxh.Trim();                  //变速箱号

                    Mgzd.cph = gzd.cph.Trim();                    //车牌号

                    Mgzd.clyt = gzd.clyt.Trim();                  //车辆用途

                    Mgzd.scrq = scrq;   //生产日期
                    Mgzd.xlrq = xlrq;   //修理日期
                    Mgzd.splb = splb;   //索赔类别

                    //配件索赔时
                    if (splb == "2")
                    {
                        Mgzd.xlrq0 = xlrq0;             //购件日期 
                        Mgzd.xslc0 = int.Parse(xslc0);  //购件里程
                        Mgzd.wtsh0 = wtsh0;             //购件单号
                        Mgzd.fwzh0 = fwzh0;             //购件站号
                    }
                    else
                    {
                        Mgzd.xlrq0 = "";
                        Mgzd.xslc0 = 0;
                        Mgzd.wtsh0 = "";
                        Mgzd.fwzh0 = "";
                    }

                    Mgzd.lzrq = lzrq;                   //开票日期
                    Mgzd.xslc = int.Parse(xslc);        //行驶里程

                    Mgzd.gzcd = gzd.gzcd.Trim();                        //故障等级
                    Mgzd.gzfl = gzd.gzfl.Trim();                        //故障分类
                    Mgzd.vsn = vsn;                                     //VSN

                    Mgzd.jdgw = gzd.jdgw.Trim();                        //接待顾问
                    Mgzd.zxg = gzd.zxg.Trim();                          //主修工

                    Mgzd.ssjdm = gzd.ssjdm.Trim();                      //故障件号
                    Mgzd.gzlbdm = gzd.gzlbdm.Trim();                    //故障模式代码 

                    Mgzd.gzms = gzms;                                   //故障描述
                    Mgzd.cljg = cljg;                                   //原因分析 检查结果

                    Mgzd.jybz = gzd.jybz.Trim();                        //是否救援

                    Mgzd.czymc = gzd.czymc.Trim();                      //操作员名称
                    Mgzd.spjhm = gzd.spjhm.Trim();                      //索赔激活码

                    Mgzd.qtfy = qtfy;

                    Mgzd.pdisqdh = pdisqdh;                             //PDI单号
                    Mgzd.pdism = pdism;                                 //PDI说明
                    Mgzd.pdibz = pdibz;                                 //PDI标志
                    Mgzd.fwzh1 = pdifwzh;                               //PDI服务站号

                    Mgzd.shbz = "";
                    Mgzd.jjbz = "";
                    Mgzd.jsbz = "";

                    //审核日期（这里就是单据退回日期）
                    if (Mgzd.shrq == null)
                        thrq = "";
                    else
                        thrq = Mgzd.shrq.Trim();

                    Mgzd.sbwxysqdh = wxysqdh;                           //三包维修预申请单

                    #endregion

                    #region 索赔工时

                    Igzdgs = SaveGzdgs(gzd.gzdgsList, fwzh, wxfc, wx_sqdh, xlrq, scrq, vsn, gsbz, out msg, out gwh);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (Igzdgs == null || Igzdgs.Count == 0)
                    {
                        errmsg = "工时信息不能为空";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    #endregion

                    #region 索赔材料

                    Igzdcl = SaveGzdcl(gzd.gzdclList, fwzh, wx_sqdh, xlrq, cx, out msg, out clh);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    #endregion

                    #region 判断工时中是否存在特殊工时代码，存在的话不能有材料

                    // 索赔单中有特殊工时代码的不能添加材料
                    if (clh != "")
                    {
                        if (chk_tsgs(Igzdgs) == true)
                        {
                            errmsg = "工时代码前4位为【970A、980A】或者工时代码为【730R9225】，不能有索赔材料！";
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }
                    #endregion

                    #region 判断是否是服务活动
                    //检查是否是参加服务活动的车辆
                    hdbh = "";
                    hdbz = "0";
                    msg = Bfwhd.chk_fwhd(vin, cx, xh_xhk, gsbz, scrq, lzrq, int.Parse(xslc), spq_xhk, splc_xhk, xlrq, fwzh, splb, Igzdgs, Igzdcl, out hdbh, out fwhd_sckzbz);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    if (hdbh != "")
                    {
                        if (spfc == "")
                        {
                            hdbz = "1";
                            Mgzd.hdbh = hdbh;
                        }
                        else
                        {
                            //如果是分厂提交的单子，是服务活动，清空服务活动编号
                            hdbh = "";
                        }
                    }
                    // 服务活动上传控制判断
                    if (!(hdbh != "" && fwhd_sckzbz == "1"))
                    {
                        msg = Bfwhd.chk_fwhd_sckz(vin, cx, scrq, lzrq, int.Parse(xslc), spq_xhk, splc_xhk, fwzh);
                        if (msg != "")
                        {
                            errmsg = msg;
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            continue;
                        }
                    }

                    #endregion

                    #region 验证材料的部件厂代码  &&  验证材料与部件厂对应关系 && 材料与配件关联型号

                    msg = chk_cl_bjc(Igzdcl, cx, pjxh, csm, vsn);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    #endregion

                    #region 验证工时的寒冷属性  &&  验证工时的活动专属标志
                    msg = Tgzd.chk_gs(Igzdgs, fwzh, splb, pp_xhk, xlrq, gsbz);
                    if (msg != "")
                    {
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    #endregion

                    #region 三包预警判断
                    if (flag == "New" && sbyjrq != "")  // 判断是否已开通三包预警功能;flag==New,退回再上传的单子不需要调用接口
                    {
                        // 修理日期在开通三包预警功能之后
                        if (xlrq.CompareTo(sbyjrq) >= 0)
                        {
                            #region 查询预警信息或查询预警申请单信息
                            if (wxysqdh == "")
                            {
                                try
                                {
                                    // 这里需要传spfc,因为80～99分站没有实际网点
                                    int t = checkEWInfo(vin, xslc, fwzh + spfc, jzrq, jzsj, Igzdcl, wx_sqdh);
                                    if (t == 1)
                                    {
                                        //没有预警信息
                                    }
                                    else if (t == 0)
                                    {
                                        errmsg = "请查询预警状态，并按提示处理";
                                        resultDict.Add("sqdh", wx_sqdh);
                                        resultDict.Add("errmsg", errmsg);
                                        resultList.Add(resultDict);
                                        continue;
                                    }
                                    else if (t < 0)
                                    {
                                        errmsg = "查询预警信息时错误";
                                        resultDict.Add("sqdh", wx_sqdh);
                                        resultDict.Add("errmsg", errmsg);
                                        resultList.Add(resultDict);
                                        continue;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    errmsg = "查询预警信息时出错：" + ex.Message.Trim();
                                    resultDict.Add("sqdh", wx_sqdh);
                                    resultDict.Add("errmsg", errmsg);
                                    resultList.Add(resultDict);
                                    continue;
                                }
                            }
                            else
                            {
                                Msbyjfkd = Bsbyjfkd.GetModelBySbwxsqdh(wxysqdh);
                                if (Msbyjfkd == null)
                                {
                                    errmsg = "查询不到对应的三包预警预申请单信息！";
                                    resultDict.Add("sqdh", wx_sqdh);
                                    resultDict.Add("errmsg", errmsg);
                                    resultList.Add(resultDict);
                                    continue;
                                }
                                if (Msbyjfkd.dph.Trim().ToUpper() != vin)
                                {
                                    errmsg = "索赔单中车辆信息与三包预警预申请单中车辆信息不一致！";
                                    resultDict.Add("sqdh", wx_sqdh);
                                    resultDict.Add("errmsg", errmsg);
                                    resultList.Add(resultDict);
                                    continue;
                                }
                                if (Msbyjfkd.zt.Trim() != "2")
                                {
                                    errmsg = "对应的三包预申请单未审批同意！";
                                    resultDict.Add("sqdh", wx_sqdh);
                                    resultDict.Add("errmsg", errmsg);
                                    resultList.Add(resultDict);
                                    continue;
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion

                    //10：-------------------------------------------其他验证

                    msg = Tgzd.chk_gzd_DMS(xlrq, thrq, lzrq, vin, vsn.Substring(0, 4), fwzh, Mgzd.ssjdm, Mgzd.gzlbdm, clh, gwh, Mgzd.jybz, splb, cx, gsbz, hdbz, ppFlag, Mgzd.xslc);
                    if (string.IsNullOrEmpty(msg.Trim()) == false)
                    {
                        //--------------------------------------------验证失败，返回失败sqdh，下一个循环
                        errmsg = msg;
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    //-------------------------------------------计算索赔单费用
                    if (calc_fwzje(ref Mgzd, Igzdgs, Igzdcl, vsn.Substring(0, 4), cx, pp_xhk) == false)
                    {
                        errmsg = "获取服务站材料管理费时出错";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }

                    // 索赔预申请关联提醒
                    if (chk_sbtx(fwzh, clh, gwh, cx, gsbz) == true)
                    {
                        Memo = "索赔单中的主材料或主工时需要关联索赔预申请报告！";
                    }
                    // 金额不一致的提醒
                    if (Decimal.Round(Mgzd.fwzje, 2, MidpointRounding.AwayFromZero) != fwzje)
                    {
                        Memo = Memo + "  申请金额" + fwzje + "与索赔系统计算出来的金额" + Decimal.Round(Mgzd.fwzje, 2, MidpointRounding.AwayFromZero) + "不一致,原因可能是本地系统基础代码库与售后索赔结算系统的基础代码库不一致引起的。";
                    }


                    //判断对应工单是否已上传
                    //Mwts = Twts.GetModel(fwzh, fc, wtsh);
                    //if (Mwts == null)
                    //{
                    //    Memo = Memo + "  索赔单对应的工单还未上传";
                    //}

                    Mgzd.gsbz = gsbz;       //工时标准
                    Mgzd.cx = cx;           //车型平台
                    Mgzd.jdrq = server_rq;  //上传日期
                    if (spfc == "")         //总厂上传时，没有材料状态为已审件，有材料为未审件
                    {
                        Mgzd.cc_xgbz = "1";
                        if (Igzdcl.Count <= 0)
                        {
                            Mgzd.zt = "2";
                            Mgzd.jjbz = "√";
                            Mgzd.jjrdm = "99999";
                            Mgzd.jjrmc = "【自动】";
                            Mgzd.jjsm = "";
                            Mgzd.sm = "";
                            Mgzd.sjrq = "";
                        }
                        else
                        {
                            Mgzd.zt = "1";
                        }
                    }
                    else
                    {
                        Mgzd.zt = "9";      //分厂上传时，状态为待提交          
                    }
                    Mgzd.wxscbz = "1";                  //维修（DMS）上传标志
                    Mgzd.wxsqdh = wx_sqdh;              //维修系统中索赔单号

                    //第一次上传
                    if (flag == "New")
                    {
                        #region 添加操作

                        Mgzd.cardid = "";
                        sqdh = Tgzd.GetMaxSqdh(fwzh, xlrq);
                        Mgzd.sqdh = sqdh;                   //申请单号
                        Mgzd.spyf = sqdh.Substring(0, 6);   //索赔月份

                        // 再次检查单子是否已上传
                        gzd_ds = Tgzd.GetList(" dph='" + vin + "' and fwzh='" + fwzh + "' and wxsqdh='" + wx_sqdh + "' and fc='" + wxfc + "' and wtsh='" + wtsh + "'");
                        if (gzd_ds.Tables[0].Rows.Count > 0)
                        {
                            //--------------------------------------------
                            if (gzd_ds.Tables[0].Rows[0]["zt"].ToString().Trim() == "8" || gzd_ds.Tables[0].Rows[0]["zt"].ToString().Trim() == "9")
                            {
                                errmsg = "正在处理上一次上传信息，请稍后再重新上传！";
                                resultDict.Add("sqdh", wx_sqdh);
                                resultDict.Add("errmsg", errmsg);
                                resultList.Add(resultDict);
                              
                                continue;
                            }
                            else
                            {
                                sqdh = gzd_ds.Tables[0].Rows[0]["sqdh"].ToString().Trim();
                                resultDict.Add("sqdh", wx_sqdh);
                                resultDict.Add("sqdh_sh", sqdh);
                                resultDict.Add("errmsg", "success");
                                resultDict.Add("memo", Memo);
                                resultList.Add(resultDict);
                                //succeed = succeed + wx_sqdh + "/";
                                //succeednew = succeednew + sqdh + "|" + Memo + "/";
                                //num = num + 1;
                                continue;
                            }
                        }

                        Igzd.Clear();
                        Igzd.Add(Mgzd);
                        for (k = 0; k < Igzdgs.Count; k++)
                        {
                            Igzdgs[k].sqdh = sqdh;
                        }
                        //生成旧件标签号和材料维修次数
                        Createjjbq(ref Igzdcl, xlrq, fwzh, sh_sqdh, vin);

                        for (k = 0; k < Igzdcl.Count; k++)
                        {
                            Igzdcl[k].sqdh = sqdh;
                        }

                        Smsg = Tgzd.Spjd_Rtmsg(Igzd, Igzdgs, Igzdcl, hdbh);

                        if (Smsg != "")
                        {
                            //--------------------------------------------保存失败，返回失败sqdh，下一个循环
                            errmsg = Smsg;
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                           
                            //continue;
                        }
                        else
                        {
                            //--------------------------------------------保存成功，返回成功sqdh
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("sqdh_sh", sqdh);
                            resultDict.Add("errmsg", "success");
                            resultDict.Add("memo", Memo);
                            resultList.Add(resultDict);

                            //succeed = succeed + wx_sqdh + "/";
                            //succeednew = succeednew + sqdh + "|" + Memo + "/";
                            //num = num + 1;


                            #region 更新车辆信息
                            if ((sqwxycscbz != "1" && spfc == "") || xh_clxx == "")
                            {
                                try
                                {
                                    //开票日期为空时的车辆,客户信息不更新到“车辆信息”中
                                    if (lzrq != "")
                                    {
                                        mclxx.yhmc = yhmc;
                                        mclxx.dz = gzd.dz.Trim();
                                        mclxx.yhdh = yhdh;
                                        mclxx.yb = gzd.yb.Trim();
                                        mclxx.cph = gzd.cph.Trim();
                                        mclxx.clyt = gzd.clyt.Trim();
                                        mclxx.lxr = lxr;
                                        mclxx.lxrdh = lxrdh;
                                        if (lzrq_clxx == "")
                                            mclxx.lzrq = lzrq;
                                    }
                                    if (xh_clxx == "")
                                        mclxx.xh = xh_xhk;
                                    mclxx.mile = int.Parse(xslc);

                                    Bclxx.Update(mclxx);
                                }
                                catch
                                { }
                            }
                            #endregion
                        }

                        #endregion
                    }
                    else
                    {
                        #region 修改操作

                        if (Mgzd.CARDID_JSBZ != "1")
                        {
                            Mgzd.cardid = "";
                        }
                        sqdh = sh_sqdh;
                        Mgzd.sqdh = sqdh;

                        for (k = 0; k < Igzdgs.Count; k++)
                        {
                            Igzdgs[k].sqdh = sqdh;
                        }
                        //生成旧件标签号和材料维修次数
                        Createjjbq(ref Igzdcl, xlrq, fwzh, sh_sqdh, vin);
                        for (k = 0; k < Igzdcl.Count; k++)
                        {
                            Igzdcl[k].sqdh = sqdh;
                        }

                        Smsg = Tgzd.Update(Mgzd, Igzdgs, Igzdcl, hdbh);
                        if (Smsg != "")
                        {
                            errmsg = Smsg;
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("errmsg", errmsg);
                            resultList.Add(resultDict);
                            //continue;
                        }
                        else
                        {
                            resultDict.Add("sqdh", wx_sqdh);
                            resultDict.Add("sqdh_sh", sqdh);
                            resultDict.Add("errmsg", "success");
                            resultDict.Add("memo", Memo);
                            resultList.Add(resultDict);

                            //succeed = succeed + wx_sqdh + "/";
                            //succeednew = succeednew + sqdh + "|" + Memo + "/";
                            //num = num + 1;

                            #region 更新车辆信息
                            if ((sqwxycscbz != "1" && spfc == "") || xh_clxx == "")
                            {
                                try
                                {
                                    //开票日期为空时的车辆,客户信息不更新到“车辆信息”中
                                    if (lzrq != "")
                                    {
                                        mclxx.yhmc = yhmc;
                                        mclxx.dz = gzd.dz.Trim();
                                        mclxx.yhdh = yhdh;
                                        mclxx.yb = gzd.yb.Trim();
                                        mclxx.cph = gzd.cph.Trim();
                                        mclxx.clyt = gzd.clyt.Trim();
                                        mclxx.lxr = lxr;
                                        mclxx.lxrdh = lxrdh;
                                        if (lzrq_clxx == "")
                                            mclxx.lzrq = lzrq;
                                    }
                                    if (xh_clxx == "")
                                        mclxx.xh = xh_xhk;
                                    mclxx.mile = int.Parse(xslc);

                                    Bclxx.Update(mclxx);
                                }
                                catch
                                { }
                            }
                            #endregion
                        }

                        #endregion
                    }

                    // 日志记录
                    //AddJkLog(fwzh, sqdh, vin, startTime, DateTime.Now, "1");

                }
                catch (Exception ex)
                {
                    errmsg = ex.Message.Replace("\r\n", "").Replace("。", "");
                    resultDict.Add("sqdh", wx_sqdh);
                    resultDict.Add("errmsg", errmsg);
                    resultList.Add(resultDict);
                    //lost = lost + wx_sqdh + "|" + errmsg + "/";
                    continue;
                }
            }

            msg = "success";
            return resultList;
        }
        #endregion

        public List<inputGhfwhdCx> getGhFwhdCxListFromJson(JavaScriptArray array)
        {
            List<inputGhfwhdCx> list = new List<inputGhfwhdCx>();
            inputGhfwhdCx model = null;
            foreach (JavaScriptObject obj in array)
            {
                model = new inputGhfwhdCx();
                model.fwzh = obj["fwzh"].ToString().Trim();
                model.sjfc = obj["sjfc"].ToString().Trim();
                model.wtsh = obj["wtsh"].ToString().Trim();
                model.hdbh = obj["hdbh"].ToString().Trim();
                model.dph = obj["dph"].ToString().Trim();
                list.Add(model);
            }
            return list;
        }

        public List<inputGhfwhd> getGhFwhdListFromJson(JavaScriptArray hdArray)
        {
            List<inputGhfwhd> list = new List<inputGhfwhd>();
            inputGhfwhd ghfwhd = null;
            foreach (JavaScriptObject obj in hdArray)
            {
                ghfwhd = new inputGhfwhd();
                ghfwhd.fwzh = obj["fwzh"].ToString().Trim();
                ghfwhd.sjfc = obj["sjfc"].ToString().Trim();
                ghfwhd.wtsh = obj["wtsh"].ToString().Trim();
                ghfwhd.hdbh = obj["hdbh"].ToString().Trim();
                ghfwhd.dph = obj["dph"].ToString().Trim();
                ghfwhd.cjrq = obj["cjrq"].ToString().Trim();
                ghfwhd.xslc = obj["xslc"].ToString().Trim();
                ghfwhd.bykh = obj["bykh"].ToString().Trim();
                ghfwhd.sxr = obj["sxr"].ToString().Trim();
                ghfwhd.sxr_sjh = obj["sxr_sjh"].ToString().Trim();

                list.Add(ghfwhd);
            }

            return list;
        }

        public List<input_sbd> getSbdListFromJson(JavaScriptArray sbdArray)
        {
            List<input_sbd> list = new List<input_sbd>();
            List<input_sbdpdi> pdiList = new List<input_sbdpdi>();
            input_sbd sbd = new input_sbd();
            input_sbdpdi pdi = null;
            JavaScriptArray pdiArray;
            foreach (JavaScriptObject obj in sbdArray)
            {
                sbd = new input_sbd();
                sbd.fwzh = obj["fwzh"].ToString().Trim();
                sbd.sqdh = obj["sqdh"].ToString().Trim();
                sbd.sh_sqdh = obj["sh_sqdh"].ToString().Trim();
                sbd.sjfc = obj["sjfc"].ToString().Trim();

                sbd.lzrq = obj["lzrq"].ToString().Trim();
                sbd.byrq = obj["byrq"].ToString().Trim();
                sbd.scrq = obj["scrq"].ToString().Trim();
                sbd.srrq = obj["srrq"].ToString().Trim();

                sbd.bycs = obj["bycs"].ToString().Trim();
                sbd.vsn = obj["vsn"].ToString().Trim();
                sbd.dph = obj["dph"].ToString().Trim();
                sbd.xh = obj["xh"].ToString().Trim();
                sbd.fdjh = obj["fdjh"].ToString().Trim();
                sbd.bsxh = obj["bsxh"].ToString().Trim();
                sbd.clyt = obj["clyt"].ToString().Trim();
                sbd.cph = obj["cph"].ToString().Trim();
                sbd.yqdh = obj["yqdh"].ToString().Trim();
                sbd.yhmc = obj["yhmc"].ToString().Trim();
                sbd.yhdh = obj["yhdh"].ToString().Trim();
                sbd.dz = obj["dz"].ToString().Trim();
                sbd.yb = obj["yb"].ToString().Trim();
                sbd.lxr = obj["lxr"].ToString().Trim();
                sbd.zfbz = obj["zfbz"].ToString().Trim();
                sbd.pdibz = obj["pdibz"].ToString().Trim();
                sbd.jtbz = obj["jtbz"].ToString().Trim();
                sbd.memo = obj["memo"].ToString().Trim();
                sbd.jdgw = obj["jdgw"].ToString().Trim();
                sbd.zxg = obj["zxg"].ToString().Trim();
                sbd.bslc = obj["bslc"].ToString().Trim();
                sbd.hblc = obj["hblc"].ToString().Trim();
                sbd.czydm = obj["czydm"].ToString().Trim();
                sbd.czymc = obj["czymc"].ToString().Trim();
                sbd.gsf = obj["gsf"].ToString().Trim();
                sbd.clf = obj["clf"].ToString().Trim();
                sbd.byje = obj["byje"].ToString().Trim();
                try
                {
                    sbd.sbjhm = obj["sbjhm"].ToString().Trim();
                    if (sbd.bycs != "2")
                        sbd.sbjhm = "";
                }
                catch
                {
                    sbd.sbjhm = "";
                }
                try
                {
                    sbd.jcrq = obj["jcrq"].ToString().Trim();
                }
                catch
                {
                    sbd.jcrq = "";
                }
                try
                {
                    #region pdi检查项目
                    pdiArray = obj["pdiList"] as JavaScriptArray;
                    pdiList = new List<input_sbdpdi>();
                    foreach (JavaScriptObject pdiObj in pdiArray)
                    {
                        pdi = new input_sbdpdi();
                        pdi.fwzh = pdiObj["fwzh"].ToString().Trim();
                        pdi.sqdh = pdiObj["sqdh"].ToString().Trim();
                        pdi.fc = pdiObj["fc"].ToString().Trim();
                        pdi.gzdm = pdiObj["gzdm"].ToString().Trim();
                        pdi.gzmc = pdiObj["gzmc"].ToString().Trim();
                        pdi.xmdm = pdiObj["xmdm"].ToString().Trim();
                        pdi.xmmc = pdiObj["xmmc"].ToString().Trim();
                        pdi.lxdm = pdiObj["lxdm"].ToString().Trim();
                        pdi.lxmc = pdiObj["lxmc"].ToString().Trim();
                        pdi.bwdm = pdiObj["bwdm"].ToString().Trim();
                        pdi.bwmc = pdiObj["bwmc"].ToString().Trim();
                        pdi.gzms = pdiObj["gzms"].ToString().Trim();

                        pdiList.Add(pdi);
                    }
                    #endregion
                }
                catch
                {
                    pdiList = null;
                }
              

                sbd.pdiList = pdiList;

                list.Add(sbd);
            }
            return list;
        }

        //获取索赔单信息，从json对象中
        public List<inputGzd> getGzdListFromJson(JavaScriptArray gzdArray)
        {
            List<inputGzd> list = new List<inputGzd>();
            List<inputGzdCl> clList = new List<inputGzdCl>();
            List<inputGzdGs> gsList = new List<inputGzdGs>();
            inputGzdCl cl = null;
            inputGzdGs gs = null;
            JavaScriptArray clArray;
            JavaScriptArray gsArray;
            inputGzd gzd = new inputGzd();
            foreach(JavaScriptObject obj in gzdArray)
            {
                gzd = new inputGzd();

                #region 索赔单信息
                gzd.fwzh = obj["fwzh"].ToString().Trim();
                gzd.sqdh = obj["sqdh"].ToString().Trim();
                gzd.sh_sqdh = obj["sh_sqdh"].ToString().Trim();
                gzd.sjfc = obj["sjfc"].ToString().Trim();
                gzd.lzrq = obj["lzrq"].ToString().Trim();
                gzd.scrq = obj["scrq"].ToString().Trim();
                gzd.srrq = obj["srrq"].ToString().Trim();
                gzd.dph = obj["dph"].ToString().Trim();
                gzd.vsn = obj["vsn"].ToString().Trim();
                gzd.xh = obj["xh"].ToString().Trim();
                gzd.fdjh = obj["fdjh"].ToString().Trim();
                gzd.splb = obj["splb"].ToString().Trim();
                gzd.wtsh = obj["wtsh"].ToString().Trim();
                gzd.yhmc = obj["yhmc"].ToString().Trim();
                gzd.yhdh = obj["yhdh"].ToString().Trim();
                gzd.lxr = obj["lxr"].ToString().Trim();
                gzd.sjh = obj["sjh"].ToString().Trim();
                gzd.gzms = obj["gzms"].ToString().Trim();
                gzd.cljg = obj["cljg"].ToString().Trim();
                gzd.xlrq = obj["xlrq"].ToString().Trim();
                gzd.xslc = obj["xslc"].ToString().Trim();

                gzd.qtfy = obj["qtfy"].ToString().Trim();
                gzd.fwzje = obj["fwzje"].ToString().Trim();
                gzd.fwzh0 = obj["fwzh0"].ToString().Trim();
                gzd.wtsh0 = obj["wtsh0"].ToString().Trim();
                gzd.xlrq0 = obj["xlrq0"].ToString().Trim();
                gzd.xslc0 = obj["xslc0"].ToString().Trim();

                gzd.pdisqdh = obj["pdisqdh"].ToString().Trim();
                gzd.wxysqdh = obj["wxysqdh"].ToString().Trim();
                gzd.jzrq = obj["jzrq"].ToString().Trim();
                gzd.jzsj = obj["jzsj"].ToString().Trim();
                gzd.fwzh1 = obj["fwzh1"].ToString().Trim();
                gzd.dz = obj["dz"].ToString().Trim();
                gzd.yb = obj["yb"].ToString().Trim();
                gzd.bsxh = obj["bsxh"].ToString().Trim();
                gzd.cph = obj["cph"].ToString().Trim();
                gzd.clyt = obj["clyt"].ToString().Trim();
                gzd.gzcd = obj["gzcd"].ToString().Trim();
                gzd.gzfl = obj["gzfl"].ToString().Trim();
                gzd.jdgw = obj["jdgw"].ToString().Trim();
                gzd.zxg = obj["zxg"].ToString().Trim();
                gzd.ssjdm = obj["ssjdm"].ToString().Trim();
                gzd.gzlbdm = obj["gzlbdm"].ToString().Trim();
                gzd.jybz = obj["jybz"].ToString().Trim();
                gzd.czymc = obj["czymc"].ToString().Trim();
                try
                {
                    gzd.spjhm = obj["spjhm"].ToString().Trim();
                }
                catch
                {
                    gzd.spjhm = "";
                }
                #endregion
                #region 索赔单工时
                gsArray = obj["gzdgsList"] as JavaScriptArray;
                gsList = new List<inputGzdGs>();
                foreach (JavaScriptObject gsObj in gsArray)
                {
                    gs = new inputGzdGs();
                    gs.fwzh = gsObj["fwzh"].ToString().Trim();
                    gs.sqdh = gsObj["sqdh"].ToString().Trim();
                    gs.fc = gsObj["fc"].ToString().Trim();
                    gs.bh = gsObj["bh"].ToString().Trim();
                    gs.gwh = gsObj["gwh"].ToString().Trim();
                    gs.zt = gsObj["zt"].ToString().Trim();
                    gs.jfbz = gsObj["jfbz"].ToString().Trim();
                    gs.obd1 = gsObj["obd1"].ToString().Trim();
                    gs.obd2 = gsObj["obd2"].ToString().Trim();
                  
                    gsList.Add(gs);
                }
                #endregion
                #region 索赔单材料
                clArray = obj["gzdclList"] as JavaScriptArray;
                clList = new List<inputGzdCl>();
                foreach (JavaScriptObject clObj in clArray)
                {
                    cl = new inputGzdCl();
                    cl.fwzh = clObj["fwzh"].ToString().Trim();
                    cl.sqdh = clObj["sqdh"].ToString().Trim();
                    cl.fc = clObj["fc"].ToString().Trim();
                    cl.clh = clObj["clh"].ToString().Trim();
                    cl.cls = clObj["cls"].ToString().Trim();
                    cl.zt = clObj["zt"].ToString().Trim();
                    cl.bjzzcdm = clObj["bjzzcdm"].ToString().Trim();
                    cl.qtbjcmc = clObj["qtbjcmc"].ToString().Trim();
                    cl.gzms = clObj["gzms"].ToString().Trim();
                    cl.clxh1 = clObj["clxh1"].ToString().Trim();
                    cl.clxh2 = clObj["clxh2"].ToString().Trim();
                    cl.bjc2 = clObj["bjc2"].ToString().Trim();
                    cl.ldhj = clObj["ldhj"].ToString().Trim();
                    clList.Add(cl);
                }
                #endregion

                gzd.gzdgsList = gsList;
                gzd.gzdclList = clList;

                list.Add(gzd);
            }
            return list;

        }

        public List<inputWts> getWtsListFromJson(JavaScriptArray wtsArray)
        {
            List<inputWts> list = new List<inputWts>();
            List<inputWtsCl> clList = new List<inputWtsCl>();
            List<inputWtsWxxm> xmList = new List<inputWtsWxxm>();
            inputWtsCl cl = null;
            inputWtsWxxm xm = null;
            JavaScriptArray clArray;
            JavaScriptArray xmArray;
            inputWts wts = new inputWts();
            foreach (JavaScriptObject obj in wtsArray)
            {
                wts = new inputWts();

                #region 委托书信息
                wts.FWZH = obj["FWZH"].ToString().Trim();
                wts.FC = obj["FC"].ToString().Trim();
                wts.WTSH = obj["WTSH"].ToString().Trim();
                wts.GCRQ = obj["GCRQ"].ToString().Trim();
                wts.SBRQ = obj["SBRQ"].ToString().Trim();
                wts.SCRQ = obj["SCRQ"].ToString().Trim();
                wts.JZRQ = obj["JZRQ"].ToString().Trim();
                wts.JZSJ = obj["JZSJ"].ToString().Trim();
                wts.KDRQ = obj["KDRQ"].ToString().Trim();
                wts.KDSJ = obj["KDSJ"].ToString().Trim();
                wts.DPH = obj["DPH"].ToString().Trim();
                wts.VSN = obj["VSN"].ToString().Trim();
                wts.FDJH = obj["FDJH"].ToString().Trim();
                wts.XH = obj["XH"].ToString().Trim();
                wts.DW_CZ = obj["DW_CZ"].ToString().Trim();
                wts.DZ = obj["DZ"].ToString().Trim();
                wts.YB = obj["YB"].ToString().Trim();
                wts.SJH = obj["SJH"].ToString().Trim();
                wts.SXR = obj["SXR"].ToString().Trim();
                wts.CPH = obj["CPH"].ToString().Trim();
                wts.CLYS = obj["CLYS"].ToString().Trim();
                if (string.IsNullOrEmpty(obj["HLCBBZ"].ToString().Trim()))
                    wts.HLCBBZ = false;
                else
                    wts.HLCBBZ = bool.Parse(obj["HLCBBZ"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["SPJDBZ"].ToString().Trim()))
                    wts.SPJDBZ = false;
                else
                    wts.SPJDBZ = bool.Parse(obj["SPJDBZ"].ToString().Trim());
                wts.HLCBRQ = obj["HLCBRQ"].ToString().Trim();
                wts.XLLB_DM = obj["XLLB_DM"].ToString().Trim();
                if (string.IsNullOrEmpty(obj["JCLC"].ToString().Trim()))
                    wts.JCLC = 0;
                else
                    wts.JCLC = int.Parse(obj["JCLC"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["HBLC"].ToString().Trim()))
                    wts.HBLC = 0;
                else
                    wts.HBLC = int.Parse(obj["HBLC"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["XSLC"].ToString().Trim()))
                    wts.XSLC = 0;
                else
                    wts.XSLC = int.Parse(obj["XSLC"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["XCBYLC"].ToString().Trim()))
                    wts.XCBYLC = 0;
                else
                    wts.XCBYLC = int.Parse(obj["XCBYLC"].ToString().Trim());

                wts.JDGW = obj["JDGW"].ToString().Trim();
                wts.XXY = obj["XXY"].ToString().Trim();
                if (string.IsNullOrEmpty(obj["HJ"].ToString().Trim()))
                    wts.HJ = 0;
                else
                    wts.HJ = decimal.Parse(obj["HJ"].ToString().Trim());
                wts.BSXH = obj["BSXH"].ToString().Trim();
                wts.GSBZ = obj["GSBZ"].ToString().Trim();
                wts.BXDQ = obj["BXDQ"].ToString().Trim();
                wts.SXR_XB = obj["SXR_XB"].ToString().Trim();
                wts.ZJHM = obj["ZJHM"].ToString().Trim();
                wts.LCFS = obj["LCFS"].ToString().Trim();
                wts.SXR_SJH = obj["SXR_SJH"].ToString().Trim();
                wts.ZXG = obj["ZXG"].ToString().Trim();
                wts.GZMS = obj["GZMS"].ToString().Trim();
                wts.CBZD = obj["CBZD"].ToString().Trim();

                wts.YJWGRQ = obj["YJWGRQ"].ToString().Trim();
                wts.YJWGSJ = obj["YJWGSJ"].ToString().Trim();
                wts.KHHFYD = obj["KHHFYD"].ToString().Trim();
                wts.XCBYRQ = obj["XCBYRQ"].ToString().Trim();
                if (string.IsNullOrEmpty(obj["CCLC"].ToString().Trim()))
                    wts.CCLC = 0;
                else
                    wts.CCLC = int.Parse(obj["CCLC"].ToString().Trim());
                wts.BGFS = obj["BGFS"].ToString().Trim();
                if (string.IsNullOrEmpty(obj["BGF"].ToString().Trim()))
                    wts.BGF = 0;
                else
                    wts.BGF = decimal.Parse(obj["BGF"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["SGF"].ToString().Trim()))
                    wts.SGF = 0;
                else
                    wts.SGF = decimal.Parse(obj["SGF"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["GJFY"].ToString().Trim()))
                    wts.GJFY = 0;
                else
                    wts.GJFY = decimal.Parse(obj["GJFY"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["GFYH"].ToString().Trim()))
                    wts.GFYH = 0;
                else
                    wts.GFYH = decimal.Parse(obj["GFYH"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["CLYH"].ToString().Trim()))
                    wts.CLYH = 0;
                else
                    wts.CLYH = decimal.Parse(obj["CLYH"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["GSDJ"].ToString().Trim()))
                    wts.GSDJ = 0;
                else
                    wts.GSDJ = decimal.Parse(obj["GSDJ"].ToString().Trim());
                wts.JFSX = obj["JFSX"].ToString().Trim();
                if (string.IsNullOrEmpty(obj["WJGF"].ToString().Trim()))
                    wts.WJGF = 0;
                else
                    wts.WJGF = decimal.Parse(obj["WJGF"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["JCF"].ToString().Trim()))
                    wts.JCF = 0;
                else
                    wts.JCF = decimal.Parse(obj["JCF"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["YSGF"].ToString().Trim()))
                    wts.YSGF = 0;
                else
                    wts.YSGF = decimal.Parse(obj["YSGF"].ToString().Trim());
                if (string.IsNullOrEmpty(obj["YSCL"].ToString().Trim()))
                    wts.YSCL = 0;
                else
                    wts.YSCL = decimal.Parse(obj["YSCL"].ToString().Trim());

                wts.CK = obj["CK"].ToString().Trim();
                wts.SYRL = obj["SYRL"].ToString().Trim();
                wts.KDR = obj["KDR"].ToString().Trim();
                wts.KDWCRQ = obj["KDWCRQ"].ToString().Trim();
                wts.KDWCSJ = obj["KDWCSJ"].ToString().Trim();
                wts.PGR = obj["PGR"].ToString().Trim();
                wts.PGRQ = obj["PGRQ"].ToString().Trim();
                wts.PGSJ = obj["PGSJ"].ToString().Trim();
                wts.KGRQ = obj["KGRQ"].ToString().Trim();
                wts.KGSJ = obj["KGSJ"].ToString().Trim();
                wts.WGRQ = obj["WGRQ"].ToString().Trim();
                wts.WGSJ = obj["WGSJ"].ToString().Trim();
                wts.WGSCR = obj["WGSCR"].ToString().Trim();
                wts.WGSCRQ = obj["WGSCRQ"].ToString().Trim();
                wts.WGSCSJ = obj["WGSCSJ"].ToString().Trim();
                wts.JSR = obj["JSR"].ToString().Trim();
                wts.JSRQ = obj["JSRQ"].ToString().Trim();
                wts.JSSJ = obj["JSSJ"].ToString().Trim();
                wts.JCRQ = obj["JCRQ"].ToString().Trim();
                wts.JCSJ = obj["JCSJ"].ToString().Trim();
                wts.CP_DM = obj["CP_DM"].ToString().Trim();
                wts.SCPCH = obj["SCPCH"].ToString().Trim();
                wts.SXR_DWDH = obj["SXR_DWDH"].ToString().Trim();
                wts.SXR_JTDH = obj["SXR_JTDH"].ToString().Trim();
                wts.CX = obj["CX"].ToString().Trim();
                wts.DWDH = obj["DWDH"].ToString().Trim();
                wts.JTDH = obj["JTDH"].ToString().Trim();
                wts.LZRQ = obj["LZRQ"].ToString().Trim();
                wts.ZT = obj["ZT"].ToString().Trim();

                #endregion
                #region 维修项目
                xmArray = obj["XMLIST"] as JavaScriptArray;
                xmList = new List<inputWtsWxxm>();
                foreach (JavaScriptObject xmObj in xmArray)
                {
                    xm = new inputWtsWxxm();
                    xm.FWZH = xmObj["FWZH"].ToString().Trim();
                    xm.FC = xmObj["FC"].ToString().Trim();
                    xm.WTSH = xmObj["WTSH"].ToString().Trim();
                    xm.GSBZ = xmObj["GSBZ"].ToString().Trim();
                    xm.GWBH = xmObj["GWBH"].ToString().Trim();
                    xm.GWMC = xmObj["GWMC"].ToString().Trim();
                    xm.XMXZ = xmObj["XMXZ"].ToString().Trim();
                    if (xmObj["BZGF"].ToString().Trim() != "")
                        xm.BZGF = decimal.Parse(xmObj["BZGF"].ToString().Trim());
                    if (xmObj["SSGF"].ToString().Trim() != "")
                        xm.SSGF = decimal.Parse(xmObj["SSGF"].ToString().Trim());
                    if (xmObj["XLGS"].ToString().Trim() != "")
                        xm.XLGS = decimal.Parse(xmObj["XLGS"].ToString().Trim());
                    if (xmObj["FJGS"].ToString().Trim() != "")
                        xm.FJGS = decimal.Parse(xmObj["FJGS"].ToString().Trim());

                    xm.XLG = xmObj["XLG"].ToString().Trim();
                    xm.BZMC = xmObj["BZMC"].ToString().Trim();
                    xm.GZJH = xmObj["GZJH"].ToString().Trim();
                    xm.GZDH = xmObj["GZDH"].ToString().Trim();
                    xm.GZMS = xmObj["GZMS"].ToString().Trim();
                    xm.XLLB = xmObj["XLLB"].ToString().Trim();
                    xm.CLJG = xmObj["CLJG"].ToString().Trim();
                    if (xmObj["SPGS"].ToString().Trim() != "")
                        xm.SPGS = decimal.Parse(xmObj["SPGS"].ToString().Trim());
                    if (xmObj["SP_GSDJ"].ToString().Trim() != "")
                        xm.SP_GSDJ = decimal.Parse(xmObj["SP_GSDJ"].ToString().Trim());
                    if (xmObj["YGLF"].ToString().Trim() != "")
                        xm.YGLF = decimal.Parse(xmObj["YGLF"].ToString().Trim());

                    xm.GZ = xmObj["GZ"].ToString().Trim();
                    xm.KGRQ = xmObj["KGRQ"].ToString().Trim();
                    xm.KGSJ = xmObj["KGSJ"].ToString().Trim();
                    xm.WGRQ = xmObj["WGRQ"].ToString().Trim();
                    xm.WGSJ = xmObj["WGSJ"].ToString().Trim();
                    xm.JYY = xmObj["JYY"].ToString().Trim();
                    xm.BZ = xmObj["BZ"].ToString().Trim();
                    xm.OBD1 = xmObj["OBD1"].ToString().Trim();
                    xm.OBD2 = xmObj["OBD2"].ToString().Trim();

                    xmList.Add(xm);
                }
                #endregion
                #region 维修材料
                clArray = obj["CLLIST"] as JavaScriptArray;
                clList = new List<inputWtsCl>();
                foreach (JavaScriptObject clObj in clArray)
                {
                    cl = new inputWtsCl();
                    cl.FWZH = clObj["FWZH"].ToString().Trim();
                    cl.FC = clObj["FC"].ToString().Trim();
                    cl.WTSH = clObj["WTSH"].ToString().Trim();
                    cl.CLDL = clObj["CLDL"].ToString().Trim();
                    cl.CLH = clObj["CLH"].ToString().Trim();
                    cl.CLMC = clObj["CLMC"].ToString().Trim();
                    if (clObj["SL"].ToString().Trim() != "")
                        cl.SL = decimal.Parse(clObj["SL"].ToString().Trim());
                    cl.JLDW = clObj["JLDW"].ToString().Trim();
                    cl.PCH = clObj["PCH"].ToString().Trim();
                    if (clObj["CKJ"].ToString().Trim() != "")
                        cl.CKJ = decimal.Parse(clObj["CKJ"].ToString().Trim());
                    cl.CLXZ = clObj["CLXZ"].ToString().Trim();
                    cl.LLY = clObj["LLY"].ToString().Trim();
                    cl.LLRQ = clObj["LLRQ"].ToString().Trim();
                    cl.LLSJ = clObj["LLSJ"].ToString().Trim();
                    cl.FLR = clObj["FLR"].ToString().Trim();
                    cl.BZ = clObj["BZ"].ToString().Trim();
                    cl.BXDH = clObj["BXDH"].ToString().Trim();
                    if (clObj["GRJ"].ToString().Trim() != "")
                        cl.GRJ = decimal.Parse(clObj["GRJ"].ToString().Trim());
                    if (clObj["SPJ"].ToString().Trim() != "")
                        cl.SPJ = decimal.Parse(clObj["SPJ"].ToString().Trim());
                    cl.HWH = clObj["HWH"].ToString().Trim();
                    cl.SYCX = clObj["SYCX"].ToString().Trim();
                    cl.gzms = clObj["GZMS"].ToString().Trim();
                    cl.clxh1 = clObj["CLXH1"].ToString().Trim();
                    cl.clxh2 = clObj["CLXH2"].ToString().Trim();
                    cl.bjc2 = clObj["BJC2"].ToString().Trim();
                    cl.bjzzcdm = clObj["BJZZCDM"].ToString().Trim();
                    cl.qtbjcmc = clObj["QTBJCMC"].ToString().Trim();
                    clList.Add(cl);
                }
                #endregion

                wts.xmList = xmList;
                wts.clList = clList;
                wts.fjList = new List<inputWtsFj>();
                list.Add(wts);
            }
            return list;

        }

        protected Dictionary<string, object> gzdModelToDict(SIS.Model.gzd Mgzd)
        {
            if (Mgzd == null)
                return null;
            Dictionary<string, object> dt = new Dictionary<string, object>();

            dt.Add("fwzh", Mgzd.fwzh.Trim());
            dt.Add("sqdh", Mgzd.sqdh.Trim());
            dt.Add("zt", Mgzd.zt.Trim());//状态
            dt.Add("shbz", Mgzd.shbz.Trim());//审核标志
            dt.Add("jjbz", Mgzd.jjbz.Trim());//审件标志
            dt.Add("jjsm", Mgzd.jjsm.Trim());//审件说明
            dt.Add("sm", Mgzd.sm.Trim());//电脑一审说明
            dt.Add("sm1", Mgzd.sm1.Trim());//一审说明
            dt.Add("sm2", Mgzd.sm2.Trim());//二审说明
            dt.Add("jsrq", Mgzd.jsrq.Trim());//结算日期
            dt.Add("jsbh", Mgzd.jsbh.Trim());//结算编号
            dt.Add("qtfy", Mgzd.qtfy.ToString());//其他费用
            dt.Add("gsf", Mgzd.gsf.ToString());//工时费
            dt.Add("clf", Mgzd.clf.ToString());//材料费
            dt.Add("glf", Mgzd.glf.ToString());//管理费
            dt.Add("flf", Mgzd.flf.ToString());//辅料费
            dt.Add("fwf", Mgzd.fwf.ToString());//服务费
            dt.Add("bcf", Mgzd.bcf.ToString());//补偿费
            dt.Add("zkje", Mgzd.zkje.ToString());//扣款金额
            dt.Add("fwzje", Mgzd.fwzje.ToString());//服务站申请金额
            dt.Add("spje", Mgzd.spje.ToString());//审核金额
            dt.Add("tzje", Mgzd.tzje.ToString());//调整金额

            List<Dictionary<string, string>> clList = new List<Dictionary<string, string>>();
            Dictionary<string, string> clht = null;
            if (Mgzd.zt.Trim() == "8")
            {
                //返回索赔单材料信息
                SIS.BLL.gzdcl gzdcl = new SIS.BLL.gzdcl();
                DataSet clds = new DataSet();
                clds = gzdcl.GetList(" fwzh='" + Mgzd.fwzh.Trim() + "' and sqdh='" + Mgzd.sqdh.Trim() + "'");
                if (clds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < clds.Tables[0].Rows.Count; i++)
                    {
                        clht = new Dictionary<string, string>();
                        clht.Add("clh", clds.Tables[0].Rows[i]["clh"].ToString().Trim());
                        clht.Add("cls", clds.Tables[0].Rows[i]["cls"].ToString().Trim());
                        clht.Add("jjbq", clds.Tables[0].Rows[i]["jjbq"].ToString().Trim());

                        clList.Add(clht);
                    }
                }
            }
            dt.Add("gzdcl", clList);
            return dt;
        }


        /// <summary>
        /// 工单日期逻辑
        /// </summary>
        /// <returns></returns>
        private static string gd_chkrq(string jzrq, string gcrq, string sbrq, string scrq, string kdrq)
        {
            //---------------------------------判断日期
            int xtrq1, xlrq1, lzrq1, sbrq1, scrq1, kdrq1;
            string Msg = "";
            xtrq1 = int.Parse(DateTime.Now.ToString("yyyyMMdd"));//系统当前日期
            int.TryParse(jzrq, out xlrq1);//修理日期
            int.TryParse(gcrq, out lzrq1);//开票日期
            int.TryParse(sbrq, out sbrq1);//首保日期
            int.TryParse(scrq, out scrq1);//生产日期
            int.TryParse(kdrq, out kdrq1);//开单日期
            if (xlrq1 > xtrq1)
            {
                Msg = "修理日期大于系统当前日期";
                return Msg;
            }
            if (lzrq1 > xtrq1)
            {
                Msg = "开票日期大于系统当前日期";
                return Msg;
            }
            if (sbrq1 > xtrq1)
            {
                Msg = "首保日期大于系统当前日期";
                return Msg;
            }
            //if (xlrq1 > kdrq1)
            //{
            //    Msg = "修理日期大于开单日期";
            //    return Msg;
            //}
            if (lzrq1 != 0)
            {
                if (lzrq1 < scrq1)
                {
                    Msg = "生产日期大于开票日期";
                    return Msg;
                }
                if (lzrq1 > xlrq1)
                {
                    Msg = "开票日期大于修理日期";
                    return Msg;
                }
            }
            return Msg;
        }
        /// <summary>
        /// 索赔单日期逻辑判断
        /// </summary>
        /// <returns></returns>
        private static string spd_chkrq(string txtLzrq, string txtScrq, string txtXlrq, string lblSrrq, string ddlSplb)
        {
            //-----------------------日期判断---------------------------
            string Msg = "";
            int lzrq = 0, xtrq = 0, scrq = 0, xlrq = 0, srrq = 0;
            xtrq = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int.TryParse(txtLzrq, out lzrq);//开票日期
            int.TryParse(txtScrq, out scrq);//生产日期
            int.TryParse(txtXlrq, out xlrq);//修理日期
            int.TryParse(lblSrrq, out srrq);//输入日期

            if (lzrq > xtrq)
            {
                Msg = "开票日期大于系统当前日期";
                return Msg;
            }
            if (lzrq != 0)
            {
                if (scrq > lzrq)
                {
                    Msg = "开票日期小于生产日期";
                    return Msg;
                }
            }
            if (ddlSplb == "0" || ddlSplb == "2")
            {
                if (lzrq != 0)
                {
                    if (lzrq > xlrq)
                    {
                        Msg = "开票日期大于修理日期";
                        return Msg;
                    }
                }
            }
            if (xlrq > srrq)
            {
                Msg = "修理日期大于输入日期";
                return Msg;
            }
            if (xlrq > xtrq)
            {
                Msg = "修理日期大于系统日期";
                return Msg;
            }

            return Msg;
        }
        /// <summary>
        /// 保养单日期逻辑判断
        /// </summary>
        /// <returns></returns>
        private string byd_chkrq(string txtLzrq, string txtScrq, string txtByrq, string txtSrrq, string Bycs)
        {
            //---------------------------------判断日期-------------------------------
            string Msg = "";
            int scrq, lzrq, xtrq, byrq, srrq;
            xtrq = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int.TryParse(txtLzrq, out lzrq);
            int.TryParse(txtScrq, out scrq);
            int.TryParse(txtByrq, out byrq);
            int.TryParse(txtSrrq, out srrq);

            if (lzrq > xtrq)
            {
                Msg = "开票日期大于系统当前日期";
                return Msg;
            }
            if (byrq > srrq)
            {
                Msg = "保养日期大于输入日期";
                return Msg;
            }
            if (byrq > xtrq)
            {
                Msg = "保养日期大于系统当前日期";
                return Msg;
            }
            if (scrq > xtrq)
            {
                Msg = "生产日期大于系统当前日期";
                return Msg;
            }
            if (lzrq != 0)
            {
                if (scrq > lzrq)
                {
                    Msg = "开票日期小于生产日期";
                    return Msg;
                }
            }
            if (Bycs != "1")
            {
                if (lzrq > byrq)
                {
                    Msg = "保养日期小于开票日期";
                    return Msg;
                }
            }
            return Msg;
        }

        /// <summary>
        /// 索赔单-工时
        /// </summary>
        /// <param name="afwzh"></param>
        /// <param name="afc"></param>
        /// <param name="aWtsh"></param>
        /// <returns></returns>
        private static IList<SIS.Model.gzdgs> SaveGzdgs(List<inputGzdGs> inputGsList, string fwzh, string fch, string aSqdh, string xlrq, string scrq, string vsn, string gsbz, out string rtmsg, out string gwh)
        {
            gwh = "";
            rtmsg = "";
            string msg, gwmc, gwbh;
            decimal gss, gsf, flf, gssMax;
            int indexMax;
            SIS.BLL.gzd gzd = new SIS.BLL.gzd();
            SIS.Model.gzdgs dm = null;

            IList<SIS.Model.gzdgs> gzdgs = new List<SIS.Model.gzdgs>();
            //-------------------------过滤
            //DataRow[] dr = dt.Select("sqdh='" + aSqdh + "' and fwzh='" + fwzh + "'", "zt desc");
            //inputGsList.Sort();

            foreach (inputGzdGs datarow in inputGsList)
            {
                if (datarow.fwzh.Trim().ToUpper() != fwzh.Trim().ToUpper() || datarow.sqdh.Trim() != aSqdh.Trim())
                {
                    continue;
                }
                dm = new SIS.Model.gzdgs();
                dm.fwzh = datarow.fwzh.Trim();
                dm.fc = datarow.fc.Trim();
                dm.sqdh = datarow.sqdh.Trim();

                dm.bh = int.Parse(datarow.bh.Trim());

                gwbh = datarow.gwh.Trim().ToUpper();
                dm.gwh = gwbh;

                msg = gzd.calc_gsf(fwzh, fch, vsn.Substring(0, 4), gwbh, xlrq, scrq, out gwmc, out gss, out gsf, out flf);

                if (msg == "")
                {
                    if (gwmc == "")
                    {
                        rtmsg = "工时代码" + gwbh + "不正确或与工时标准不对应";
                        return null;
                    }
                    if (gwmc == "已停用")
                    {
                        rtmsg = "工时代码" + gwbh + "在索赔系统中已停用";
                        return null;
                    }
                    dm.gwmc = gwmc;
                    dm.gss = gss;
                    dm.gsf = gsf;
                    dm.flf = flf;
                }
                else
                {
                    rtmsg = "工时代码" + gwbh + msg;
                    return null;
                }

                dm.jfbz = datarow.jfbz.Trim();
                dm.zt = datarow.zt.Trim();

                dm.obd1 = datarow.obd1.Trim();
                dm.obd2 = datarow.obd2.Trim();

                gzdgs.Add(dm);
            }

            string Maxgwh = "";
            string Maxgwh_Last = "";
            string Othergwh = "", Othergwh_Last = "";
            decimal OthergssMax = -1;
            int OtherindexMax = -1;
            decimal R_gssMax = -1;
            int R_indexMax = -1;
            decimal L_gssMax = -1;
            int L_indexMax = -1;

            gssMax = -1;
            indexMax = -1;

            #region 取最主工位
            for (int j = 0; j < gzdgs.Count; j++)
            {
                if (j == 0)
                {
                    gssMax = gzdgs[j].gss;
                    indexMax = j;
                    Maxgwh = gzdgs[j].gwh;
                    Maxgwh_Last = Maxgwh.Substring(Maxgwh.Length - 1, 1).ToUpper();
                }
                else
                {
                    if (gzdgs[j].gss >= gssMax)
                    {
                        //最大工时数相同情况
                        if (gzdgs[j].gss == gssMax)
                        {
                            //1：最后位全是数字或全是字母，就取最前面的；
                            if (Maxgwh_Last == "R" || Maxgwh_Last == "L")
                            {
                                Othergwh = gzdgs[j].gwh;
                                Othergwh_Last = Othergwh.Substring(Othergwh.Length - 1, 1).ToUpper();
                                //取最后位没有字母L或R的作为主
                                if (Othergwh_Last != "R" && Othergwh_Last != "L")
                                {
                                    gssMax = gzdgs[j].gss;
                                    indexMax = j;
                                    Maxgwh = gzdgs[j].gwh;
                                    Maxgwh_Last = Maxgwh.Substring(Maxgwh.Length - 1, 1).ToUpper();
                                }
                                else
                                {
                                    //最后位全是字母取最前面的
                                }
                            }
                            else
                            {
                                //2：最后位既有数字也有字母，取最后位没有字母L或R的作为主
                            }
                        }
                        else
                        {
                            gssMax = gzdgs[j].gss;
                            indexMax = j;
                            Maxgwh = gzdgs[j].gwh;
                            Maxgwh_Last = Maxgwh.Substring(Maxgwh.Length - 1, 1).ToUpper();
                        }
                    }
                }
            }
            #endregion

            gwh = Maxgwh;   //最大工位号

            Othergwh = "";
            Othergwh_Last = "";
            OthergssMax = -1;
            OtherindexMax = -1;
            R_gssMax = -1;
            R_indexMax = -1;
            L_gssMax = -1;
            L_indexMax = -1;

            //最大工位号,最后一位不是R/L
            if (Maxgwh_Last != "L" && Maxgwh_Last != "R")
            {
                #region 主工位，最后一位不是R/L
                for (int j = 0; j < gzdgs.Count; j++)
                {
                    if (j != indexMax)
                    {
                        Othergwh = gzdgs[j].gwh;
                        Othergwh_Last = Othergwh.Substring(Othergwh.Length - 1, 1).ToUpper();

                        #region 取所有最后位是R的工时最大工时数，其他都算0
                        if (Othergwh_Last == "R")
                        {
                            if (R_indexMax == -1)
                            {
                                R_gssMax = gzdgs[j].gss;
                                R_indexMax = j;
                            }
                            else
                            {
                                if (gzdgs[j].gss > R_gssMax)
                                {
                                    gzdgs[R_indexMax].gsf = 0;
                                    gzdgs[R_indexMax].flf = 0;
                                    R_gssMax = gzdgs[j].gss;
                                    R_indexMax = j;
                                }
                                else
                                {
                                    gzdgs[j].gsf = 0;
                                    gzdgs[j].flf = 0;
                                }
                            }
                        }
                        #endregion

                        #region 取所有最后位是L的工时最大工时数，其他都算0
                        else if (Othergwh_Last == "L")
                        {
                            if (L_indexMax == -1)
                            {
                                L_gssMax = gzdgs[j].gss;
                                L_indexMax = j;
                            }
                            else
                            {
                                if (gzdgs[j].gss > L_gssMax)
                                {
                                    gzdgs[L_indexMax].gsf = 0;
                                    gzdgs[L_indexMax].flf = 0;
                                    L_gssMax = gzdgs[j].gss;
                                    L_indexMax = j;
                                }
                                else
                                {
                                    gzdgs[j].gsf = 0;
                                    gzdgs[j].flf = 0;
                                }
                            }
                        }
                        #endregion

                        #region 最后位不是L/R,由于主工时也不是L/R,所以不用计算
                        else
                        {
                            gzdgs[j].gsf = 0;
                            gzdgs[j].flf = 0;
                        }
                        #endregion

                        gzdgs[j].zt = "0";
                    }
                    else
                    {
                        gzdgs[j].zt = "1";  //主工时
                    }
                }
                #endregion
            }
            else
            {
                #region 主工位，最后一位是R/L
                for (int j = 0; j < gzdgs.Count; j++)
                {
                    if (j != indexMax)
                    {
                        Othergwh = gzdgs[j].gwh;
                        Othergwh_Last = Othergwh.Substring(Othergwh.Length - 1, 1).ToUpper();

                        #region 其他所有最后位是数字,不是L/R的工时，最大一个算工时，其他都算0
                        if (Othergwh_Last != "L" && Othergwh_Last != "R")
                        {
                            if (OtherindexMax == -1)
                            {
                                OthergssMax = gzdgs[j].gss;
                                OtherindexMax = j;
                            }
                            else
                            {
                                if (gzdgs[j].gss > OthergssMax)
                                {
                                    gzdgs[OtherindexMax].gsf = 0;
                                    gzdgs[OtherindexMax].flf = 0;
                                    OthergssMax = gzdgs[j].gss;
                                    OtherindexMax = j;
                                }
                                else
                                {
                                    gzdgs[j].gsf = 0;
                                    gzdgs[j].flf = 0;
                                }
                            }
                        }
                        #endregion

                        #region 其他工位最后位和最大工位最后位不相同，最大一个算工时，其他都算0
                        else if (Othergwh_Last != Maxgwh_Last)
                        {
                            if (R_indexMax == -1)
                            {
                                R_gssMax = gzdgs[j].gss;
                                R_indexMax = j;
                            }
                            else
                            {
                                if (gzdgs[j].gss > R_gssMax)
                                {
                                    gzdgs[R_indexMax].gsf = 0;
                                    gzdgs[R_indexMax].flf = 0;
                                    R_gssMax = gzdgs[j].gss;
                                    R_indexMax = j;
                                }
                                else
                                {
                                    gzdgs[j].gsf = 0;
                                    gzdgs[j].flf = 0;
                                }
                            }
                        }
                        #endregion

                        #region 其他工位最后位和最大工位最后位相同，都算0
                        else
                        {
                            gzdgs[j].gsf = 0;
                            gzdgs[j].flf = 0;
                        }
                        #endregion

                        gzdgs[j].zt = "0";
                    }
                    else
                    {
                        gzdgs[j].zt = "1";  //主工时
                    }
                }
                #endregion
            }
            return gzdgs;
        }

        /// <summary>
        /// 索赔单-材料
        /// </summary>
        /// <param name="afwzh"></param>
        /// <param name="afc"></param>
        /// <param name="aWtsh"></param>
        /// <returns></returns>
        private static IList<SIS.Model.gzdcl> SaveGzdcl(List<inputGzdCl> inputClList, string afwzh, string aSqdh, string xlrq, string cx, out string msg, out string clh)
        {
            clh = "";
            msg = "";
            string sqdh_tmp = "";
            string clbh, clmc, djbz, bfjbz, tsclbz;
            decimal cldj;
            int bh = 0;

            SIS.BLL.gzd gzd = new SIS.BLL.gzd();
            IList<SIS.Model.gzdcl> Igzdcl = new List<SIS.Model.gzdcl>();

            //-------------------------数据集过滤
            //DataRow[] dr = dt.Select("sqdh='" + aSqdh + "' and fwzh='" + afwzh + "'", "zt desc");
            inputClList.Sort();
            SIS.Model.gzdcl Mgzdcl = new SIS.Model.gzdcl();
            //
            foreach (inputGzdCl datarow in inputClList)
            {
                if (datarow.fwzh.Trim().ToUpper() != afwzh.Trim().ToUpper() || datarow.sqdh.Trim() != aSqdh.Trim())
                {
                    continue;
                }
                Mgzdcl = new SIS.Model.gzdcl();

                Mgzdcl.fwzh = datarow.fwzh.Trim();
                Mgzdcl.fc = datarow.fc.Trim();
                Mgzdcl.sqdh = aSqdh;
                if (Mgzdcl.sqdh != sqdh_tmp)
                {
                    bh = 0;
                    sqdh_tmp = aSqdh;
                }
                bh = bh + 1;
                Mgzdcl.bh = bh;

                clbh = datarow.clh.Trim().ToUpper();

                gzd.calc_cldj(afwzh, cx, clbh, xlrq, out clmc, out cldj, out djbz, out bfjbz, out tsclbz);
                if (clmc == "")
                {
                    msg = "材料" + clbh + "不正确或与车型平台不对应";
                    return null;
                }
                if (clmc == "已停用")
                {
                    msg = "材料" + clbh + "已停用";
                    return null;
                }

                Mgzdcl.clh = clbh;
                Mgzdcl.clmc = clmc;

                // 判断材料数是否为整数（20160411）
                if (SIS.Common.StringPlus.CheckDecimalStringIsInteger(datarow.cls.Trim()) == false)
                {
                    msg = "索赔单材料中的材料数量必须是整数";
                    return null;
                }

                if (string.IsNullOrEmpty(datarow.cls.Trim()))
                    Mgzdcl.cls = 0;
                else
                    Mgzdcl.cls = decimal.Parse(datarow.cls.Trim());

                Mgzdcl.cldj = cldj;
                Mgzdcl.clf = Mgzdcl.cls * cldj;
                //Mgzdcl.zt = datarow["zt"].ToString();
                if (bh == 1)
                    Mgzdcl.zt = "1";
                else
                    Mgzdcl.zt = "0";
                Mgzdcl.djbz = djbz;
                Mgzdcl.wxcs = 0;
                Mgzdcl.jjsm = "";
                Mgzdcl.hgs = 0;
                Mgzdcl.clfbjc = 0;
                Mgzdcl.jjbz = "";
                Mgzdcl.bfjbz = bfjbz;
                Mgzdcl.zjbz = "";
                Mgzdcl.tsclbz = tsclbz;
                Mgzdcl.zxh = "";
                Mgzdcl.gzms = datarow.gzms.Trim();
                Mgzdcl.clxh1 = datarow.clxh1.Trim();
                Mgzdcl.clxh2 = datarow.clxh2.Trim();
                Mgzdcl.bjc2 = datarow.bjc2.Trim();
                Mgzdcl.bjzzcdm = datarow.bjzzcdm.Trim();
                Mgzdcl.qtbjcmc = datarow.qtbjcmc.Trim();
                Mgzdcl.jjbq = "";
                try
                {
                    // 连带换件
                    Mgzdcl.ldhj = datarow.ldhj.ToString();
                }
                catch
                {
                    Mgzdcl.ldhj = "";
                }

                if (bh == 1 && datarow.zt == "1")
                {
                    clh = datarow.clh.ToString();             //返回主材料号
                }

                Igzdcl.Add(Mgzdcl);
            }

            return Igzdcl;

        }

        /// <summary>
        /// 保养单-PDI检查项目
        /// </summary>
        /// <param name="afwzh"></param>
        /// <param name="afc"></param>
        /// <param name="aWtsh"></param>
        /// <returns></returns>
        private static IList<SIS.Model.sbd_pdi> SaveSbdPdi(List<input_sbdpdi> inputPdiList, string afwzh, string aSqdh, out string msg)
        {
           
            msg = "";
            IList<SIS.Model.sbd_pdi> Isbdpdi = new List<SIS.Model.sbd_pdi>();

            //-------------------------数据集过滤
       
            SIS.Model.sbd_pdi Msbdpdi = new SIS.Model.sbd_pdi();
            SIS.BLL.pdi_jcxmgz Bjcxmgz = new BLL.pdi_jcxmgz();
            SIS.BLL.pdi_jcxm Bjcxm = new BLL.pdi_jcxm();
            SIS.BLL.pdi_gzlx Bgzlx = new BLL.pdi_gzlx();
            SIS.BLL.pdi_gzbw Bgzbw = new BLL.pdi_gzbw();
            SIS.Model.pdi_jcxmgz Mjcxmgz = null;
            SIS.Model.pdi_jcxm Mjcxm = null;
            SIS.Model.pdi_gzlx Mgzlx = null;
            SIS.Model.pdi_gzbw Mgzbw = null;
            //
            foreach (input_sbdpdi datarow in inputPdiList)
            {
                if (datarow.fwzh.Trim().ToUpper() != afwzh.Trim().ToUpper() || datarow.sqdh.Trim() != aSqdh.Trim())
                {
                    continue;
                }
                Msbdpdi = new SIS.Model.sbd_pdi();

                Msbdpdi.fwzh = datarow.fwzh.Trim();
                Msbdpdi.fc = datarow.fc.Trim();
                Msbdpdi.sqdh = aSqdh;
                Msbdpdi.gzdm = datarow.gzdm.Trim().ToUpper();
                Msbdpdi.gzms = datarow.gzms.Trim();

                if (Msbdpdi.gzms == "")
                {
                    msg = "PDI检查项目中必须填写故障描述";
                    return null;
                }
                
                //查询pdi故障症状
                if (Msbdpdi.gzdm != "QT")
                {
                    Mjcxmgz = Bjcxmgz.GetModel(Msbdpdi.gzdm);
                    if (Mjcxmgz == null)
                    {
                        msg = string.Format("故障症状：{0}{1}不正确", Msbdpdi.gzdm, datarow.gzmc.Trim());
                        return null;
                    }
                    Msbdpdi.gzmc = Mjcxmgz.gzmc.Trim();
                    Msbdpdi.xmdm = Mjcxmgz.xmdm.Trim().ToUpper();
                }
                else
                {
                    Msbdpdi.gzmc = datarow.gzmc.Trim();
                    Msbdpdi.xmdm = datarow.xmdm.Trim().ToUpper();
                }

                if (Msbdpdi.xmdm != datarow.xmdm.Trim().ToUpper())
                {
                    msg = string.Format("故障部件{0}与故障症状不对应", datarow.xmdm.Trim());
                    return null;
                }
                //查询pdi故障部件
                Mjcxm = Bjcxm.GetModel(Msbdpdi.xmdm);
                if (Mjcxm == null)
                {
                    msg = string.Format("故障部件：{0}{1}不正确", Msbdpdi.xmdm, datarow.xmmc.Trim());
                    return null;
                }
                Msbdpdi.xmmc = Mjcxm.xmmc.Trim();
                Msbdpdi.bwdm = Mjcxm.bwdm.Trim().ToUpper();
                Msbdpdi.bwmc = "";
                //检查pdi故障部位,故障部位可以为空
                if (Msbdpdi.bwdm != "")
                {
                    Mgzbw = Bgzbw.GetModel(Msbdpdi.bwdm);
                    if (Mgzbw == null)
                    {
                        msg = string.Format("故障部位：{0}{1}不正确", Msbdpdi.bwdm, datarow.bwmc.Trim());
                        return null;
                    }
                    Msbdpdi.bwmc = Mgzbw.bwmc.Trim();
                    Msbdpdi.lxdm = Mgzbw.lxdm.Trim().ToUpper();
                }
                else
                {
                    Msbdpdi.lxdm = datarow.lxdm.Trim();
                }
                
                //检查故障类型
                Msbdpdi.lxmc = "";
                if (Msbdpdi.lxdm != datarow.lxdm.Trim().ToUpper())
                {
                    msg = string.Format("故障类型{0}与故障部件不对应", datarow.lxdm.Trim());
                    return null;
                }
                Mgzlx = Bgzlx.GetModel(Msbdpdi.lxdm);
                if (Mgzlx == null)
                {
                    msg = string.Format("故障类型：{0}{1}不正确", Msbdpdi.lxdm, datarow.lxmc.Trim());
                    return null;
                }
                Msbdpdi.lxmc = Mgzlx.lxmc.Trim();
                Isbdpdi.Add(Msbdpdi);
            }

            return Isbdpdi;

        }

        /// <summary>
        /// 检查索赔单工时中是否包含特殊工时【970A****（调修类），980A****（喷漆类）、730R9225（冷媒）】，有这些工时的索赔单不能添加索赔单材料
        /// </summary>
        /// <param name="gzdgsList"></param>
        /// <returns>存在特殊工时返回true，不存在返回false</returns>
        private static bool chk_tsgs(IList<SIS.Model.gzdgs> gzdgsList)
        {
            bool flag = false;

            string tsgsTop1 = "970A";
            string tsgsTop2 = "980A";
            string tsgs = "730R9225";

            string tsgsTop = string.Empty;

            foreach (SIS.Model.gzdgs gs in gzdgsList)
            {

                if (gs.gwh.Trim().Length >= 4)
                {
                    tsgsTop = gs.gwh.Trim().ToUpper().Substring(0, 4);
                    if (tsgsTop == tsgsTop1 || tsgsTop == tsgsTop2)
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        if (gs.gwh.Trim().ToUpper() == tsgs)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }
            return flag;
        }


        /// <summary>
        /// 材料与关联型号、材料与部件厂关系检查
        /// </summary>
        /// <param name="Igzdcl">索赔单材料</param>
        /// <param name="cx">车型平台</param>
        /// <param name="pjxh">配件关联型号</param>
        /// <returns></returns>
        private static string chk_cl_bjc(IList<SIS.Model.gzdcl> Igzdcl, string cx, string pjxh, string csm, string vsn)
        {
            SIS.BLL.clk Bclk = new SIS.BLL.clk();
            SIS.Model.clk Mclk = new SIS.Model.clk();

            SIS.Model.bjzzc Mbjzzc = new SIS.Model.bjzzc();
            SIS.BLL.bjzzc Bbjzzc = new SIS.BLL.bjzzc();

            SIS.Model.bjcclk Mbjcclk = new SIS.Model.bjcclk();
            SIS.BLL.bjcclk Bbjcclk = new SIS.BLL.bjcclk();

            SIS.BLL.fdjm Bfdjm = new SIS.BLL.fdjm();
            SIS.Model.fdjm Mfdjm = new SIS.Model.fdjm();

            DataSet bjzzcclk = new DataSet();

            string errmsg = "", pjxh_tmp = "", clh, bjzzcdm, vsn56, clcsm, clktbz, clxh, clxh2, fdjbz, ktbz, cl_fdjbz;
            int index;
            bool flag = false;

            vsn56 = vsn.Substring(4, 2);    //VSN第5，6位为发动机标示
            ktbz = vsn.Substring(9, 1);     //VSN第10位指示空调，不是0表示空调车

            Mfdjm = Bfdjm.GetModel(vsn56);  //获取车辆的发动机标志
            if (Mfdjm != null)
                fdjbz = Mfdjm.fdjbz.Trim().ToUpper();
            else
                fdjbz = "";

            pjxh_tmp = pjxh.ToUpper();
            ArrayList xhk_pjxh = new ArrayList();

            while (string.IsNullOrEmpty(pjxh_tmp) == false)
            {
                if (pjxh_tmp.Substring(0, 1) == "(")
                {
                    index = pjxh_tmp.IndexOf(")");
                    if (index < 0)
                    {
                        xhk_pjxh.Add(pjxh_tmp);
                        pjxh_tmp = "";
                    }
                    else
                    {
                        xhk_pjxh.Add(pjxh_tmp.Substring(1, index - 1).Trim());
                        if ((index + 1) >= pjxh_tmp.Length)
                            pjxh_tmp = "";
                        else
                            pjxh_tmp = pjxh_tmp.Substring(index + 1).Trim();
                    }
                }
                else
                {
                    xhk_pjxh.Add(pjxh_tmp);
                    pjxh_tmp = "";
                }
            }

            foreach (SIS.Model.gzdcl bjc_gzdcl in Igzdcl)
            {
                #region 判断材料(配件关联型号、发动机号、车身类型、空调件)
                clh = bjc_gzdcl.clh.Trim();
                Mclk = Bclk.GetModel(clh, cx);
                if (Mclk != null)
                {
                    //判断配件关联型号是否对应
                    clxh = Mclk.xh.Trim().ToUpper();
                    clxh2 = Mclk.xh2.Trim().ToUpper();
                    if (xhk_pjxh.Count == 0)
                    {
                        if (clxh != "ALL" || clxh2 != "ALL")
                        {
                            errmsg = "有材料不能使用在该车型中";
                            return errmsg;
                        }
                    }
                    else
                    {
                        flag = false;
                        clxh = clxh + clxh2;
                        foreach (string str in xhk_pjxh)
                        {
                            if (clxh.IndexOf(str) >= 0)
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {
                            //msg = string.Format("材料{0}不能使用在该车型中，请检查！", clh);
                            errmsg = "有材料不能使用在该车型中";
                            return errmsg;
                        }
                    }

                    //判断车辆发动机类型与材料中的发动机类型是否一致
                    cl_fdjbz = Mclk.fdjbz.Trim().ToUpper();
                    if (cl_fdjbz != "" && fdjbz != "")
                    {
                        if (cl_fdjbz != fdjbz)
                        {
                            errmsg = "有材料与发动机不对应";
                            return errmsg;
                        }
                    }

                    //判断车身类型
                    clcsm = Mclk.csm.Trim();
                    if (csm != "" && clcsm != "" && clcsm.IndexOf(csm) < 0)
                    {
                        errmsg = "有材料与车辆的车身类型不对应";
                        return errmsg;
                    }
                    //判断空调件
                    clktbz = Mclk.ktbz.Trim().ToUpper();
                    if (ktbz == "0" && clktbz == "K")
                    {
                        errmsg = "此车为非空调车材料中不能有空调件";
                        return errmsg;
                    }
                }
                else
                {
                    errmsg = string.Format("材料号{0}不正确或与车型平台不对应", clh);
                    return errmsg;
                }
                #endregion

                #region 部件厂及材料与部件厂对应关系判断
                bjzzcdm = bjc_gzdcl.bjzzcdm.Trim();
                if (bjzzcdm != "0000000")
                {
                    //验证材料的部件厂代码是否存在
                    if (Bbjzzc.Exists(bjzzcdm) == false)
                    {
                        errmsg = "有材料的部件厂代码不正确";
                        return errmsg;
                    }
                    //验证材料与部件厂对应关系
                    bjzzcclk = Bbjcclk.GetList("clh='" + clh + "'");
                    if (bjzzcclk.Tables[0].Rows.Count > 0)  //不存在表示这个材料号在表里面没有对应关系，不判断
                    {
                        if (Bbjcclk.Exists(clh, bjzzcdm) == false)
                        {
                            errmsg = "有材料与部件厂对应关系不正确";
                            return errmsg;
                        }
                    }
                }
                #endregion
            }
            return errmsg;
        }

        /// <summary>
        /// 预警状态查询
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="xslc"></param>
        /// <param name="fwzh"></param>
        /// <param name="kdrq"></param>
        /// <param name="clk"></param>
        /// <returns></returns>
        protected int checkEWInfo(string vin, string xslc, string fwzh, string jzrq, string jzsj, IList<SIS.Model.gzdcl> Igzdcl, string wxsqdh)
        {
            int result = -1;

            DateTime startTime;
            DateTime endTime;
            // 获取调用三包预警接口方式，1：动态调用，2：静态调用
            string jkCallMode = "";
            SIS.BLL.cssz Bcssz = new SIS.BLL.cssz();
            SIS.Model.cssz Mcssz = Bcssz.GetModel("JK");
            if (Mcssz == null)
                jkCallMode = "";
            else
                jkCallMode = Mcssz.mc == null ? "" : Mcssz.mc.Trim();
            if (jkCallMode == "")
                jkCallMode = "1";

            #region 将数据转换成json格式
            StringBuilder sbr = new StringBuilder();
            sbr.Append("{\"vin\":\"");
            sbr.Append(vin);
            sbr.Append("\",\"mileAge\":");
            sbr.Append(xslc);
            sbr.Append(",\"dealerCode\":\"");
            sbr.Append(fwzh);
            sbr.Append("\",\"inboundTime\":\"");
            sbr.Append(jzrq.Insert(6, "-").Insert(4, "-") + " " + jzsj.Substring(0, 5));
            sbr.Append("\",\"parts\":");
            if (Igzdcl == null || Igzdcl.Count == 0)
            {
                sbr.Append("[{\"partCode\":\"\",\"workCode\":\"\"}]}");
            }
            else
            {
                sbr.Append("[");
                foreach (SIS.Model.gzdcl cl in Igzdcl)
                {
                    sbr.Append("{\"partCode\":\"");
                    sbr.Append(cl.clh.Trim());
                    sbr.Append("\",\"workCode\":\"\"}");
                    sbr.Append(",");
                }
                sbr.Remove(sbr.Length - 1, 1);
                sbr.Append("]}");
            }
            #endregion

            if (jkCallMode == "1")
            {
                string wjWsUrl = System.Configuration.ConfigurationManager.AppSettings["WjWebServiceUrl"];    //三包预警系统webservice地址
                if (wjWsUrl != null && wjWsUrl != "")
                {
                    Object[] obj = new object[] { sbr.ToString() };

                    startTime = DateTime.Now;

                    // 返回0代表有预警信息，返回1代表无预警信息，返回负数为出错信息
                    object objval = SIS.Common.WsCaller.InvokeWebService(wjWsUrl, "checkEWInfo", obj);

                    endTime = DateTime.Now;

                    //AddYjjkLog(fwzh, wxsqdh, vin, startTime, endTime, sbr.ToString(), objval.ToString(), "1", jkCallMode);

                    result = System.Convert.ToInt32(objval);
                }
            }
            else
            {
                startTime = DateTime.Now;
                
                cn_com_sgmw_dealer.EWInfoServiceImplService EWInfoService = new cn_com_sgmw_dealer.EWInfoServiceImplService();
                int retval = EWInfoService.checkEWInfo(sbr.ToString());

                endTime = DateTime.Now;

                //AddYjjkLog(fwzh, wxsqdh, vin, startTime, endTime, sbr.ToString(), retval.ToString(), "1", jkCallMode);

                result = retval;
            }
            return result;
        }

        /// <summary>
        /// 索赔单-计算费用
        /// </summary>
        /// <param name="model"></param>
        /// <param name="gzdgs"></param>
        /// <param name="gzdcl"></param>
        /// <returns></returns>
        private static bool calc_fwzje(ref SIS.Model.gzd model, IList<SIS.Model.gzdgs> gzdgs, IList<SIS.Model.gzdcl> gzdcl, string xh, string cx, string pp_xhk)
        {
            SIS.BLL.fwzk fwzk = new SIS.BLL.fwzk();

            decimal glfl;//材料管理费率/故障件补偿率
            decimal gss, gsf, flf, cls, clf, glf, bfj, wglf;  //工时数，工时费，辅料费，材料数，材料费，管理费，不返件费，不计算管理费的材料费用
            decimal glfl_bfj = 0;   // 管理费率－不返件
            decimal glf_bfj = 0;    // 管理费－不返件
            int i;

            if (fwzk.GetGlfl(model.fwzh, model.fc, model.xlrq, xh, cx, out glfl) == false)
            {
                return false;
            }

            gss = 0;
            gsf = 0;
            flf = 0;
            for (i = 0; i < gzdgs.Count; i++)
            {
                gss = gss + gzdgs[i].gss;
                gsf = gsf + gzdgs[i].gsf;
                flf = flf + gzdgs[i].flf;
            }

            cls = 0;
            clf = 0;
            bfj = 0;
            wglf = 0;
            for (i = 0; i < gzdcl.Count; i++)
            {
                cls = cls + gzdcl[i].cls;
                clf = clf + gzdcl[i].clf;
                if (gzdcl[i].bfjbz == "1")
                    bfj = bfj + gzdcl[i].clf;
                if (gzdcl[i].tsclbz == "1")
                    wglf = wglf + gzdcl[i].clf;
            }

            glf = (clf - bfj - wglf) * glfl / 100;
            if (bfj > 0)
            {
                glfl_bfj = fwzk.GetGlfl_Bfj(model.xlrq, pp_xhk); //获取不返件的管理费率
                glf_bfj = bfj * glfl_bfj / 100;
            }

            glf = glf + glf_bfj;

            model.gss = gss;
            model.gsf = gsf;
            model.flf = flf;
            model.cls = cls;
            model.clf = clf;
            model.glf = glf;
            model.fwzje = gsf + flf + clf + glf + model.qtfy;

            return true;
        }

        /// <summary>
        /// 判断主工时，主材料是否需要打索赔预申请报告
        /// </summary>
        /// <param name="clh"></param>
        /// <param name="gwh"></param>
        /// <param name="cx"></param>
        /// <param name="gsbz"></param>
        /// <returns></returns>
        private bool chk_sbtx(string fwzh, string clh, string gwh, string cx, string gsbz)
        {
            bool flag = false;

            if (clh != "")
            {
                SIS.BLL.clk Bclk = new BLL.clk();
                //检查材料是否需要打速报
                flag = Bclk.checkIfSb(fwzh, clh, cx);
                if (flag == true)
                    return flag;
            }
            if (gwh != "")
            {
                if (gwh == "970A0001" || gwh == "980A0000" || gwh == "990A0002")
                {
                    flag = true;
                    return flag;
                }
                SIS.BLL.gsk Bgsk = new SIS.BLL.gsk();
                SIS.Model.gsk Mgsk = Bgsk.GetModel(gsbz, gwh);
                if (Mgsk != null)
                {
                    if (Mgsk.djbz.Trim() == "1")
                    {
                        flag = true;
                        return flag;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 生成旧件标签号和材料维修次数
        /// </summary>
        /// <param name="Igzdcl"></param>
        /// <param name="xlrq"></param>
        /// <param name="afwzh"></param>
        /// <param name="sh_sqdh"></param>
        /// <param name="vin"></param>
        protected void Createjjbq(ref  IList<SIS.Model.gzdcl> Igzdcl, string xlrq, string afwzh, string sh_sqdh, string vin)
        {
            string sql = "", jjbq, maxbq, maxbq_gzd = "";
            DataSet clds = null;
            if (Igzdcl.Count > 0)
            {
                sql = " select max(jjbq) as maxjjbq from t_wts_cl where fwzh='" + afwzh + "' and jjbq like '" + xlrq.Substring(0, 6) + "%' ";
                SIS.BLL.T_WTS Twts = new SIS.BLL.T_WTS();
                maxbq = Twts.fetchStr(sql, "maxjjbq").Trim();
                if (string.IsNullOrEmpty(maxbq.Trim()))
                {
                    sql = " select max(jjbq) as maxjjbq from gzdcl where fwzh='" + afwzh + "' and jjbq like '" + xlrq.Substring(0, 6) + "%' ";
                    SIS.BLL.jjysml Tjjysml = new SIS.BLL.jjysml();
                    maxbq_gzd = Tjjysml.fetString(sql, "maxjjbq").Trim();

                    if (string.IsNullOrEmpty(maxbq_gzd.Trim()))
                    {
                        maxbq = xlrq.Substring(0, 6) + "0000";
                    }
                    else
                    {
                        maxbq = maxbq_gzd;
                    }
                }
                else
                {
                    sql = " select max(jjbq) as maxjjbq from gzdcl where fwzh='" + afwzh + "' and jjbq like '" + xlrq.Substring(0, 6) + "%' ";
                    SIS.BLL.jjysml Tjjysml = new SIS.BLL.jjysml();
                    maxbq_gzd = Tjjysml.fetString(sql, "maxjjbq").Trim();
                    if (!string.IsNullOrEmpty(maxbq_gzd.Trim()))
                    {
                        if (maxbq.CompareTo(maxbq_gzd) < 0)
                        {
                            maxbq = maxbq_gzd;
                        }
                    }
                }

                SIS.BLL.gzdcl Tgzdcl = new SIS.BLL.gzdcl();
                SIS.BLL.gzd Tgzd = new SIS.BLL.gzd();
                for (int i = 0; i < Igzdcl.Count; i++)
                {
                    if (sh_sqdh == "")
                    {
                        maxbq = (int.Parse(maxbq) + 1).ToString();
                        jjbq = maxbq;
                        Igzdcl[i].jjbq = jjbq;
                        Igzdcl[i].wxcs = Tgzd.GetClwxcs(afwzh, "", vin, "", Igzdcl[i].clh.Trim(), xlrq);    //维修次数
                    }
                    else
                    {
                        //索赔单材料中已经有这个材料
                        clds = Tgzdcl.GetList(" fwzh='" + afwzh + "' and sqdh='" + sh_sqdh + "' and clh='" + Igzdcl[i].clh.Trim() + "'");
                        if (clds.Tables[0].Rows.Count > 0)
                        {
                            Igzdcl[i].jjbq = clds.Tables[0].Rows[0]["jjbq"].ToString().Trim();
                            Igzdcl[i].wxcs = int.Parse(clds.Tables[0].Rows[0]["wxcs"].ToString().Trim());
                        }
                        else
                        {
                            maxbq = (int.Parse(maxbq) + 1).ToString();
                            jjbq = maxbq;
                            Igzdcl[i].jjbq = jjbq;
                            Igzdcl[i].wxcs = Tgzd.GetClwxcs(afwzh, "", vin, "", Igzdcl[i].clh.Trim(), xlrq);    //维修次数
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 获取参数信息
        /// </summary>
        /// <param name="bh"></param>
        /// <returns></returns>
        public SIS.Model.cssz GetCssz(string bh, ref string msg)
        {

            SIS.BLL.cssz Cssz = new SIS.BLL.cssz();
            SIS.Model.cssz Mcssz = new SIS.Model.cssz();

            try
            {
                Mcssz = Cssz.GetModel(bh);
                if (Mcssz != null)
                {
                    msg = "success";
                }
                else
                {
                    msg = "参数不存在";
                }
            }
            catch
            {
                msg = "查询参数异常";
            }
            return Mcssz;

        }

        #region--------------代码库更新（五菱售后更新到DMS维修）

        public string DataSetToString(DataTable dt)
        {
            return JavaScriptConvert.SerializeObject(dt, new DataTableConverter());
        }
        //--------------------------------代码库更新  车型库
        public DataTable DM_xhk(string time, ref string msg)
        {
            try
            {
                DataSet ds_xhk = SIS.DBUtility.SqlHelper.Query("select xhk.*,cx_gsbz.gsbz as gsbz1 from xhk left join cx_gsbz on xhk.cx=cx_gsbz.cx and xhk.mlkw=cx_gsbz.mlkw and cx_gsbz.newbz='1' ");
                DataTable dt_xhk = ds_xhk.Tables[0];
                msg = "success";
                return dt_xhk;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
           
        }


        //--------------------------------代码库更新  维修工时标准库
        public DataTable DM_gsk(string time, ref string msg)
        {
            try
            {
                DataSet ds_gsk = SIS.DBUtility.SqlHelper.Query("select * from gsk where ASCII(Upper(substring(gwh,4,1))) between 65 and 90");
                DataTable dt_gsk = ds_gsk.Tables[0];
                msg = "success";
                return dt_gsk;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
           
        }

        //--------------------------------代码库更新  材料库
        public Dictionary<string, object> DM_clk(int pageSize, int pageIndex, ref string msg)
        {
            try
            {
               
                SIS.BLL.clk Bclk = new SIS.BLL.clk();
                string strWhere = "clh<>''";
                int count = Bclk.GetTotalNumber(0, 0, 0, "", strWhere);
              
                int pageNum = (count / pageSize) + 1;
                DataSet ds = new DataSet();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("count", count);
                dic.Add("pageSize", pageSize);
                dic.Add("pageIndex", pageIndex);

                ds = Bclk.GetList(pageSize, 1, pageIndex - 1, "clh,cx", strWhere);
                dic.Add("items" , ds.Tables[0]);

                //for (int i = 0; i < pageNum; i++)
                //{
                //    ds = Bclk.GetList(pageSize, 1, i, "", strWhere);
                //    dic.Add("data" + (i + 1).ToString(),ds.Tables[0]);
                //}

                //DataSet ds_clk = SIS.DBUtility.SqlHelper.Query("select * from clk where clh<>''");
                //DataTable dt_clk = ds_clk.Tables[0];
                msg = "success";
                return dic;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  故障件库
        public DataTable DM_ssj(string time, ref string msg)
        {
            try
            {
                DataSet ds_ssj = SIS.DBUtility.SqlHelper.Query("select * from ssj");
                DataTable dt_ssj = ds_ssj.Tables[0];
                msg = "success";
                return dt_ssj;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
           
        }

        //--------------------------------代码库更新  故障件材料库
        public DataTable DM_ssjclk(string time, ref string msg)
        {
            try
            {
                DataSet ds_ssj = SIS.DBUtility.SqlHelper.Query("select * from ssj_clk");
                DataTable dt_ssj = ds_ssj.Tables[0];
                msg = "success";
                return dt_ssj;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
          
        }

        //--------------------------------代码库更新  故障件-故障模式
        public DataTable DM_ssjgzlb(string time, ref string msg)
        {
            try
            {
                DataSet ds_gzlb = SIS.DBUtility.SqlHelper.Query("select * from ssj_gzlb where len(gzlbdm)=3 ");
                DataTable dt_gzlb = ds_gzlb.Tables[0];
                msg = "success";
                return dt_gzlb;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  故障模式库
        public DataTable DM_gzlb(string time, ref string msg)
        {
            try
            {
                DataSet ds_gzlb = SIS.DBUtility.SqlHelper.Query("select * from gzlb where len(gzlbdm)=3 ");
                DataTable dt_gzlb = ds_gzlb.Tables[0];
                msg = "success";
                return dt_gzlb;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  部件厂库
        public DataTable DM_bjzzc(string time, ref string msg)
        {
            try
            {
                DataSet ds_gzlb = SIS.DBUtility.SqlHelper.Query("select * from bjzzc where substring(bjzzcdm,1,3)<>'old' ");
                DataTable dt_gzlb = ds_gzlb.Tables[0];
                msg = "success";
                return dt_gzlb;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }


        //--------------------------------代码库更新  工位-材料库
        public DataTable DM_gwcl(string time, ref string msg)
        {
            try
            {
                DataSet ds_gzlb = SIS.DBUtility.SqlHelper.Query("select * from gw_cl where ASCII(Upper(substring(gwh,4,1))) between 65 and 90  ");
                DataTable dt_gzlb = ds_gzlb.Tables[0];
                msg = "success";
                return dt_gzlb;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }

        }

        //--------------------------------代码库更新  颜色库
        public DataTable DM_ysk(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from ysk");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }


        //--------------------------------代码库更新  材料_部件厂库
        public DataTable DM_bjcclk(string time, ref string msg)
        {
            try
            {
                DataSet ds_bjcclk = SIS.DBUtility.SqlHelper.Query("select * from bjcclk  where bjzzcdm<>'' ");
                DataTable dt_bjcclk = ds_bjcclk.Tables[0];
                msg = "success";
                return dt_bjcclk;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  服务站信息
        public DataTable DM_fwzk(string fwzh, string fch, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from fwzk where fwzh='" + fwzh + "' and fch='" + fch + "'");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }
        //--------------------------------代码库更新  服务站信息
        public DataTable DM_fwzkall(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from fwzk ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  职务
        public DataTable DM_zylb(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from fwzzwb ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  职务
        public DataTable DM_xllb(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from xllb ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  维修模板
        public DataTable DM_wxmb(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from wxmb ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  维修模板-材料
        public DataTable DM_wxmb_cl(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from wxmb_cl ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  维修模板-维修项目
        public DataTable DM_wxmb_wxxm(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from wxmb_wxxm ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  车系_工时标准库
        public DataTable DM_cx_gsbz(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from cx_gsbz where newbz='1'");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  重复工时库
        public DataTable DM_gsk_cf(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from gsk_cf where Upper(ASCII(substring(gwh,4,1))) between 65 and 90 ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  电子图册
        public DataTable DM_cxt(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from cxt ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  标准库
        public DataTable DM_bzk(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from bzk ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  正负选装库
        public DataTable DM_zfxz(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from DM_ZFXZ ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }


        //--------------------------------代码库更新  服务站特定车型平台
        public DataTable DM_fwztdcx(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from fwz_tdcx ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  车型赠送保养库
        public DataTable DM_cxzsbyk(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from cx_zsbyk ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  车型赠送保养保养费
        public DataTable DM_cxsbf(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from cx_sbf ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  车辆信息赠送保养库
        public DataTable DM_clxxzsbyk(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from clxx_zsbyk ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  车辆信息赠送保养费用库
        public DataTable DM_clxxsbf(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from clxx_sbf ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }

        //--------------------------------代码库更新  替换件库
        public DataTable DM_clk_thj(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from clk_thj ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }
        public DataTable DM_clxx_zsbyk(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from clxx_zsbyk ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }
        public DataTable DM_clxx_sbf(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from clxx_sbf ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }
        public DataTable DM_cx_zsbyk(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from cx_zsbyk ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }
        public DataTable DM_cx_sbf(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from cx_sbf ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }
        public DataTable DM_fdjm(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from fdjm ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }
        public DataTable DM_pdi_gzlx(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from pdi_gzlx ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }
        public DataTable DM_pdi_gzbw(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from pdi_gzbw ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }
        public DataTable DM_pdi_jcxm(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from pdi_jcxm ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }
        public DataTable DM_pdi_jcxmgz(string time, ref string msg)
        {
            try
            {
                DataSet ds = SIS.DBUtility.SqlHelper.Query("select * from pdi_jcxmgz ");
                DataTable dt = ds.Tables[0];
                msg = "success";
                return dt;
            }
            catch
            {
                msg = "查询数据异常";
                return null;
            }
        }
        

        #endregion

        ///------------------------工单-维修项目
        /// <summary>
        /// 
        /// </summary>
        /// <param name="afwzh"></param>
        /// <param name="afc"></param>
        /// <param name="aWtsh"></param>
        /// <returns></returns>
        protected static IList<SIS.Model.T_WTS_WXXM> SaveWxxm(List<inputWtsWxxm> wxxmList, string aFwzh, string aWtsh)
        {

            string xllb = "";

            IList<SIS.Model.T_WTS_WXXM> IlWxxm = new List<SIS.Model.T_WTS_WXXM>();
            SIS.Model.T_WTS_WXXM Mwtswxxm = null;
            //-------------------------过滤
            //DataRow[] dr = dt.Select("wtsh='" + aWtsh + "' and fwzh='" + aFwzh + "'");
            foreach (inputWtsWxxm datarow in wxxmList)
            {
                if (aFwzh.ToUpper() != datarow.FWZH.Trim().ToUpper() || aWtsh.ToUpper() != datarow.WTSH.Trim().ToUpper())
                {
                    continue;
                }
                Mwtswxxm = new SIS.Model.T_WTS_WXXM();
                Mwtswxxm.FWZH = datarow.FWZH.Trim();
                Mwtswxxm.FC = datarow.FC.Trim();
                Mwtswxxm.WTSH = datarow.WTSH.Trim();

                Mwtswxxm.GSBZ = datarow.GSBZ;
                Mwtswxxm.GWBH = datarow.GWBH;
                Mwtswxxm.GWMC = datarow.GWMC;
                Mwtswxxm.XMXZ = datarow.XMXZ;

                //if (datarow["BZGF"].ToString() != "")
                //{
                //    Mwtswxxm.BZGF = decimal.Parse(datarow["BZGF"].ToString());
                //}
                //if (datarow["SSGF"].ToString() != "")
                //{
                //    Mwtswxxm.SSGF = decimal.Parse(datarow["SSGF"].ToString());
                //}
                //if (datarow["XLGS"].ToString() != "")
                //{
                //    Mwtswxxm.XLGS = decimal.Parse(datarow["XLGS"].ToString());
                //}
                //if (datarow["FJGS"].ToString() != "")
                //{
                //    Mwtswxxm.FJGS = decimal.Parse(datarow["FJGS"].ToString());
                //}
                Mwtswxxm.BZGF = datarow.BZGF;
                Mwtswxxm.SSGF = datarow.SSGF;
                Mwtswxxm.XLGS = datarow.XLGS;
                Mwtswxxm.FJGS = datarow.FJGS;

                Mwtswxxm.XLG = datarow.XLG;
                Mwtswxxm.BZMC = datarow.BZMC;
                Mwtswxxm.GZJH = datarow.GZJH;
                Mwtswxxm.GZDH = datarow.GZDH;
                Mwtswxxm.GZMS = datarow.GZMS;

                xllb = datarow.XLLB.Trim();
                //修理类别
                switch (xllb)
                {
                    case "例行保养": xllb = "保养"; break;
                    case "精品装潢": xllb = "装潢"; break;
                    case "保修索赔": xllb = "索赔"; break;
                    case "返修": xllb = "返工"; break;
                    case "强保": xllb = "免保"; break;
                    default: xllb = "小修"; break;
                }
                Mwtswxxm.XLLB = xllb;
                Mwtswxxm.BXDH = "";
                Mwtswxxm.CLJG = datarow.CLJG;
                Mwtswxxm.ZRDW = "";
                //if (datarow["SPGS"].ToString() != "")
                //{
                //    Mwtswxxm.SPGS = decimal.Parse(datarow["SPGS"].ToString());
                //}
                //if (datarow["SP_GSDJ"].ToString() != "")
                //{
                //    Mwtswxxm.SP_GSDJ = decimal.Parse(datarow["SP_GSDJ"].ToString());
                //}
                //if (datarow["YGLF"].ToString() != "")
                //{
                //    Mwtswxxm.YGLF = decimal.Parse(datarow["YGLF"].ToString());
                //}
                Mwtswxxm.SPGS = datarow.SPGS;
                Mwtswxxm.SP_GSDJ = datarow.SP_GSDJ;
                Mwtswxxm.YGLF = datarow.YGLF;

                Mwtswxxm.GZ = datarow.GZ;
                Mwtswxxm.KGRQ = datarow.KGRQ;
                Mwtswxxm.KGSJ = datarow.KGSJ;
                Mwtswxxm.WGRQ = datarow.WGRQ;
                Mwtswxxm.WGSJ = datarow.WGSJ;
                Mwtswxxm.JYY = datarow.JYY;
                Mwtswxxm.BZ = datarow.BZ;
                Mwtswxxm.obd1 = datarow.OBD1;
                Mwtswxxm.obd2 = datarow.OBD2;

                IlWxxm.Add(Mwtswxxm);
            }
            return IlWxxm;

        }

        ///------------------------工单-维修材料
        /// <summary>
        /// 
        /// </summary>
        /// <param name="afwzh"></param>
        /// <param name="afc"></param>
        /// <param name="aWtsh"></param>
        /// <returns></returns>
        protected static IList<SIS.Model.T_WTS_CL> SaveCl(List<inputWtsCl> clList, string aFwzh, string aWtsh)
        {

            IList<SIS.Model.T_WTS_CL> IlCl = new List<SIS.Model.T_WTS_CL>();

            //-------------------------过滤
            //DataRow[] dr = dt.Select("wtsh='" + aWtsh + "' and fwzh='" + aFwzh + "'");
            foreach (inputWtsCl datarow in clList)
            {
                if (aFwzh.ToUpper() != datarow.FWZH.Trim().ToUpper() || aWtsh.ToUpper() != datarow.WTSH.Trim().ToUpper())
                {
                    continue;
                }
                SIS.Model.T_WTS_CL Mwtscl = new SIS.Model.T_WTS_CL();
                Mwtscl.FWZH = datarow.FWZH.Trim();
                Mwtscl.FC = datarow.FC.Trim();
                Mwtscl.WTSH = datarow.WTSH.Trim();
                Mwtscl.CLDL = datarow.CLDL;
                Mwtscl.CLH = datarow.CLH;
                Mwtscl.CLMC = datarow.CLMC;
                //if (datarow["SL"].ToString() != "")
                //{
                //    Mwtscl.SL = decimal.Parse(datarow["SL"].ToString());
                //}
                Mwtscl.SL = datarow.SL;
                Mwtscl.JLDW = datarow.JLDW;
                Mwtscl.PCH = datarow.PCH;
                //if (datarow["CKJ"].ToString() != "")
                //{
                //    Mwtscl.CKJ = decimal.Parse(datarow["CKJ"].ToString());
                //}
                Mwtscl.CKJ = datarow.CKJ;

                Mwtscl.CLXZ = datarow.CLXZ;
                Mwtscl.LLY = datarow.LLY;
                Mwtscl.LLRQ = datarow.LLRQ;
                Mwtscl.LLSJ = datarow.LLSJ;
                Mwtscl.FLR = datarow.FLR;
                Mwtscl.BZ = datarow.BZ;
                Mwtscl.BXDH = datarow.BXDH;
                //if (datarow["GRJ"].ToString() != "")
                //{
                //    Mwtscl.GRJ = decimal.Parse(datarow["GRJ"].ToString());
                //}
                //if (datarow["SPJ"].ToString() != "")
                //{
                //    Mwtscl.SPJ = decimal.Parse(datarow["SPJ"].ToString());
                //}
                Mwtscl.GRJ = datarow.GRJ;
                Mwtscl.SPJ = datarow.SPJ;

                Mwtscl.HWH = datarow.HWH;
                Mwtscl.SYCX = datarow.SYCX;
                Mwtscl.gzms = datarow.gzms;
                Mwtscl.clxh1 = datarow.clxh1;
                Mwtscl.clxh2 = datarow.clxh2;
                Mwtscl.bjc2 = datarow.bjc2;
                Mwtscl.bjzzcdm = datarow.bjzzcdm;
                Mwtscl.qtbjcmc = datarow.qtbjcmc;
                Mwtscl.jjbq = "";

                IlCl.Add(Mwtscl);
            }

            return IlCl;

        }

        ///------------------------工单-维修附件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="afwzh"></param>
        /// <param name="afc"></param>
        /// <param name="aWtsh"></param>
        /// <returns></returns>
        protected static IList<SIS.Model.T_WTS_FJ> SaveFj(List<inputWtsFj> fjList, string aFwzh, string aWtsh)
        {

            IList<SIS.Model.T_WTS_FJ> IlFj = new List<SIS.Model.T_WTS_FJ>();
            //-------------------------过滤
            //DataRow[] dr = dt.Select("wtsh='" + aWtsh + "' and fwzh='" + aFwzh + "'");
            foreach (inputWtsFj datarow in fjList)
            {
                if (aFwzh.ToUpper() != datarow.FWZH.Trim().ToUpper() || aWtsh.ToUpper() != datarow.WTSH.Trim().ToUpper())
                {
                    continue;
                }
                SIS.Model.T_WTS_FJ Mwtsfj = new SIS.Model.T_WTS_FJ();
                Mwtsfj.FWZH = datarow.FWZH.Trim();
                Mwtsfj.FC = datarow.FC.Trim();
                Mwtsfj.WTSH = datarow.WTSH.Trim();

                //if (datarow["LSH"].ToString() != "")
                //{
                //    Mwtsfj.LSH = int.Parse(datarow["LSH"].ToString());
                //}
                Mwtsfj.LSH = datarow.LSH;

                Mwtsfj.FJ_MC = datarow.FJ_MC;
                Mwtsfj.FJHH = datarow.FJHH;
                //if (datarow["LSH_SC"].ToString() != "")
                //{
                //    Mwtsfj.LSH_SC = int.Parse(datarow["LSH_SC"].ToString());
                //}
                Mwtsfj.LSH_SC = datarow.LSH_SC;
                IlFj.Add(Mwtsfj);
            }
            return IlFj;

        }



        public class retMsg
        {
            private string _code;
            private string _msg;
            private object _data; 

            public string code
            {
                get { return this._code; }
                set { this._code = value; }
            }

            public string msg
            {
                get { return this._msg; }
                set { this._msg = value; }
            }

            public object data
            {
                get { return this._data; }
                set { this._data = value; }
            }


        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}