(function(a){a.jgrid={defaults:{recordtext:"Zeige {0} - {1} von {2}",emptyrecords:"Keine Datens&auml;tze vorhanden",loadtext:"L&auml;dt...",pgtext:"Seite {0} von {1}"},search:{caption:"Suche...",Find:"Finden",Reset:"Zur&uuml;cksetzen",odata:["gleich","ungleich","kleiner","kleiner gleich","gr&ouml;ßer","gr&ouml;ßer gleich","beginnt mit","beginnt nicht mit","ist in","ist nicht in","endet mit","endet nicht mit","enth&auml;lt","enth&auml;lt nicht"],groupOps:[{op:"AND",text:"alle"},{op:"OR",text:"mindestens eins"}],matchText:" match",rulesText:" rules"},edit:{addCaption:"Datensatz hinzuf&uuml;gen",editCaption:"Datensatz bearbeiten",bSubmit:"Speichern",bCancel:"Abbrechen",bClose:"Schließen",saveData:"Daten wurden ge&auml;ndert! &auml;nderungen speichern?",bYes:"ja",bNo:"nein",bExit:"abbrechen",msg:{required:"Feld ist erforderlich",number:"Bitte geben Sie eine Zahl ein",minValue:"Wert muss gr&ouml;ßer oder gleich sein, als ",maxValue:"Wert muss kleiner oder gleich sein, als ",email:"ist keine valide E-Mail Adresse",integer:"Bitte geben Sie eine Ganzzahl ein",date:"Bitte geben Sie ein g&uuml;ltiges Datum ein",url:"ist keine g&uuml;ltige URL. Prefix muss eingegeben werden ('http://' oder 'https://')",nodefined:" ist nicht definiert!",novalue:" R&uuml;ckgabewert ist erforderlich!",customarray:"Benutzerdefinierte Funktion sollte ein Array zur&uuml;ckgeben!",customfcheck:"Benutzerdefinierte Funktion sollte im Falle der benutzerdefinierten &uuml;berpr&uuml;fung vorhanden sein!"}},view:{caption:"Datensatz anschauen",bClose:"Schließen"},del:{caption:"L&ouml;schen",msg:"Ausgew&auml;hlte Datens&auml;tze l&ouml;schen?",bSubmit:"L&ouml;schen",bCancel:"Abbrechen"},nav:{edittext:" ",edittitle:"Ausgew&auml;hlten Zeile editieren",addtext:" ",addtitle:"Neuen Zeile einf&uuml;gen",deltext:" ",deltitle:"Ausgew&auml;hlte Zeile l&ouml;schen",searchtext:" ",searchtitle:"Datensatz finden",refreshtext:"",refreshtitle:"Tabelle neu laden",alertcap:"Warnung",alerttext:"Bitte Zeile ausw&auml;hlen",viewtext:"",viewtitle:"Ausgew&auml;hlte Zeile anzeigen"},col:{caption:"Spalten anzeigen/verbergen",bSubmit:"Speichern",bCancel:"Abbrechen"},errors:{errcap:"Fehler",nourl:"Keine URL angegeben",norecords:"Keine Datens&auml;tze zum verarbeiten",model:"colNames und colModel sind unterschiedlich lang!"},formatter:{integer:{thousandsSeparator:" ",defaultValue:"0"},number:{decimalSeparator:",",thousandsSeparator:".",decimalPlaces:2,defaultValue:"0,00"},currency:{decimalSeparator:",",thousandsSeparator:".",decimalPlaces:2,prefix:"",suffix:" €",defaultValue:"0,00"},date:{dayNames:["So","Mo","Di","Mi","Do","Fr","Sa","Sonntag","Montag","Dienstag","Mittwoch","Donnerstag","Freitag","Samstag"],monthNames:["Jan","Feb","Mar","Apr","Mai","Jun","Jul","Aug","Sep","Okt","Nov","Dez","Januar","Februar","M&auml;rz","April","Mai","Juni","Juli","August","September","Oktober","November","Dezember"],AmPm:["am","pm","AM","PM"],S:function(b){return b<11||b>13?["st","nd","rd","th"][Math.min((b-1)%10,3)]:"th"},srcformat:"Y-m-d",newformat:"d/m/Y",masks:{ISO8601Long:"d.m.Y H:i:s",ISO8601Short:"d.m.Y",ShortDate:"j.n.Y",LongDate:"l, d. F Y",FullDateTime:"l, d. F Y G:i:s",MonthDay:"d. F",ShortTime:"G:i",LongTime:"G:i:s",SortableDateTime:"Y-m-d\\TH:i:s",UniversalSortableDateTime:"Y-m-d H:i:sO",YearMonth:"F Y"},reformatAfterEdit:false},baseLinkUrl:"",showAction:"",target:"",checkbox:{disabled:true},idName:"id"}}})(jQuery);
