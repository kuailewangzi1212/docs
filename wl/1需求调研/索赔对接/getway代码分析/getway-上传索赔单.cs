
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
                    fwzh = gzd.fwzh.Trim();//服务站号*
                    wx_sqdh = gzd.sqdh.Trim();         //维修系统申请单号*
                    sh_sqdh = gzd.sh_sqdh.Trim();      //索赔系统申请单号--索赔单号*(调用接口成功后，返回索赔单号，单号要保存到经销商端，为空表示新上传)
                    wxfc = gzd.sjfc.Trim();            //实际分厂*
                    lzrq = gzd.lzrq.Trim();//开票日期X？车辆开票日期？
                    scrq = gzd.scrq.Trim();//生产日期*(车辆生产日期)
                    srrq = gzd.srrq.Trim();//输入日期*？是否为制单日期，后面有一个开单日期(jzrq)，有何区别？
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
                    xslc = gzd.xslc.Trim();//行驶里程*

                    qtfy = decimal.Parse(gzd.qtfy.Trim());    //其他费用*？手工输入？
                    fwzje = decimal.Parse(gzd.fwzje.Trim());  //服务站申请金额*？是否为（工时金额+配件金额+其他费用）?

                    fwzh0 = gzd.fwzh0.Trim();//换件服务站号X?如何取值,什么情况下填写此值？当索赔单类型是2既配件索赔时，必填？
                    wtsh0 = gzd.wtsh0.Trim();//换件委托书号X?如何取值,什么情况下填写此值?当索赔单类型是2既配件索赔时，必填？
                    xlrq0 = gzd.xlrq0.Trim();//换件日期X?如何取值,什么情况下填写此值?
                    xslc0 = gzd.xslc0.Trim();//换件里程X？如何取值,什么情况下填写此值？

                    pdisqdh = gzd.pdisqdh.Trim();//pdi申请单号X?如何取值,什么情况下填写此值?
                    wxysqdh = gzd.wxysqdh.Trim();//三包维修预申请单X?此处是预申请单单号吗？有预申请单标记的配件、工时时必填，是这样吗?
                    spjhm = gzd.spjhm.Trim();//索赔激活码X?没有此参数，请确认?

                    try
                    {
                        // 开单日期,开单时间
                        jzrq = gzd.jzrq.Trim();//开单日期*？与输入日期(srrq)，有何区别？
                        jzsj = gzd.jzsj.Trim();//开单时间*
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
                        pdifwzh = gzd.fwzh1.Trim();//如果是宝骏则需要传入PDI服务站号
                    }
                    else
                    {
                        ppFlag = SIS.Model.GlobalConst.WuLing;
                        pdifwzh = "";//非宝骏车，则为空
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

                    if (splb == "1")//splb=1售前索赔？？？
                    {
                        #region 移动到后面判断
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
                    mxhk = Bxhk.GetModel(vsn.Substring(0, 4));//mxhk是品种代码模型,?品种代码、车型平台、车型、工时标准的关系请桉楠协助整理下，原来整理的感觉有问题?
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
                    pjxh = pjxh.ToUpper();//配件型号

                    mlkw = mxhk.mlkw.Trim();//是否为发动机排量？
                    xh_xhk = mxhk.xhbh.Trim().ToUpper();//代表什么？
                    spq_xhk = mxhk.spq;//代表什么？
                    splc_xhk = mxhk.splc;//代表什么？
                    pp_xhk = mxhk.pp.Trim();//代表什么？

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

                    wsqfc_flag = false;//判断未授权网点是否允许上传单据,true表示未授权网点？
                    if (wxfc != "")//实际分厂
                    {
                        //如何判断是否为未授权网点？
                        if (PageValidate.IsNumber(wxfc) == true && int.Parse(wxfc) >= GlobalConst.unAuthorizedFcStart && int.Parse(wxfc) <= GlobalConst.unAuthorizedFcEnd)
                        {
                            spfc = "";//
                            wsqfc_flag = true;
                        }
                        else
                        {
                            spfc = wxfc;
                            wsqfc_flag = false;
                        }
                    }

                    //判断服务号
                    Mfwzk = Tfwzk.GetModel(fwzh, spfc);//参数fwzh:服务站号;spfc:是什么？返回值Mfwzk是索赔系统中的服务站信息吗？核对下是否有此字段？
                    if (Mfwzk == null)
                    {
                        errmsg = "服务站号在索赔结算系统中不存在";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断是否锁定
                    if (IsLocked.IsLockfwz(Mfwzk, xlrq) == true)//参数服务站对象、修理日期，锁定既解约，核对下是否有此字段？
                    {
                        errmsg = "服务站已解约，不能进行该操作！";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断服务站是否开通了上传功能
                    if (Mfwzk.wxscbz.Trim() != "1")//核对下是否有此字段？
                    {
                        errmsg = "服务站还没有开通上传功能";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //判断未授权网点是否允许上传单据
                    if (wsqfc_flag == true)//未授权网点
                    {
                        wsqfch = Mfwzk.ktwsqfch.Trim();//核对下是否有此字段？
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
                    sbyjrq = Mfwzk.sbyjrq.Trim();   // 三包预警启用日期--核对下是否有此字段？
                    tdcx = Mfwzk.tdcx.Trim();       // 特定车型--核对下是否有此字段？

                    //判断服务站和车是否对应
                    msg = Bxhk.IfCarInFwzh(fwzh, spfc, vsn, xlrq);//判断逻辑是什么(车与服务站的关系)？
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
                    mclxx = Bclxx.GetModel(vin);//车辆信息
                    if (mclxx == null)
                    {
                        errmsg = "车辆库中不存在该车辆信息";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //6:-------------------------------------------------此车为不索赔车辆！
                    if (mclxx.spbz.Trim() != "1")//核对下是否有此字段？
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
                    if (mclxx.fdjh.Trim().ToUpper() != fdjh)//核对下是否有此字段？
                    {
                        errmsg = "发动机号与车辆库中的发动机号不一致";
                        resultDict.Add("sqdh", wx_sqdh);
                        resultDict.Add("errmsg", errmsg);
                        resultList.Add(resultDict);
                        continue;
                    }
                    //9:-------------------------------------------------VSN码与车辆库中的VSN码不一致！
                    if (mclxx.vsn.Trim().ToUpper() != vsn)//核对下是否有此字段？
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

                    Mjsd = Bjsd.GetModel(fwzh + xlrq.Substring(0, 6));//索赔结算批次信息，确认数据营销平台是否有次信息？
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
                    if (splb == "2")//配件索赔的业务逻辑需要整理？与桉楠沟通下，下面提到的“索赔系统的购件信息”要确认下如何产生的，是否在营销平台有此数据？
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
                            if (Mgzd.zt.Trim() == "8" || Mgzd.zt.Trim() == "9")//如果索赔系统中状态为8或9(分别表示被返回和待提交)才可以再次提交？
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
                        if (gzd_ds.Tables[0].Rows.Count == 0)//新建？
                        {
                            flag = "New";
                            Mgzd = new SIS.Model.gzd();
                        }
                        else
                        {//编辑在此上传
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
                    if (clh != "")//clh:主材料号，如何取主材料号？
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