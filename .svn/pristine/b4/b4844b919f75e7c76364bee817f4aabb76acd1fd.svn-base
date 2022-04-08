import { Component, OnInit, ViewChild } from '@angular/core';
import { ServiceJksService } from '../../service-jks.service';

@Component({
  selector: 'app-home-overtime',
  templateUrl: './home-overtime.component.html',
  styleUrls: ['../home.component.css']
})
export class HomeOvertimeComponent implements OnInit {

  @ViewChild('txtqty011') txtqty011: any; @ViewChild('txtqty011_sp') txtqty011_sp: any;
  @ViewChild('txtmin011') txtmin011: any;
  @ViewChild('txttotal011') txttotal011: any;
  v_total011: number = 0;
  @ViewChild('txtqty012') txtqty012: any; @ViewChild('txtqty012_sp') txtqty012_sp: any;
  @ViewChild('txtmin012') txtmin012: any;
  @ViewChild('txttotal012') txttotal012: any;
  v_total012: number = 0;
  @ViewChild('txtqty013') txtqty013: any; @ViewChild('txtqty013_sp') txtqty013_sp: any;
  @ViewChild('txtmin013') txtmin013: any;
  @ViewChild('txttotal013') txttotal013: any;
  v_total013: number = 0;
  @ViewChild('txtqty014') txtqty014: any; @ViewChild('txtqty014_sp') txtqty014_sp: any;
  @ViewChild('txtmin014') txtmin014: any;
  @ViewChild('txttotal014') txttotal014: any;
  v_total014: number = 0;

  @ViewChild('txtqty021') txtqty021: any; @ViewChild('txtqty021_sp') txtqty021_sp: any;
  @ViewChild('txtmin021') txtmin021: any;
  @ViewChild('txttotal021') txttotal021: any;
  v_total021: number = 0;
  @ViewChild('txtqty022') txtqty022: any; @ViewChild('txtqty022_sp') txtqty022_sp: any;
  @ViewChild('txtmin022') txtmin022: any;
  @ViewChild('txttotal022') txttotal022: any;
  v_total022: number = 0;
  @ViewChild('txtqty023') txtqty023: any; @ViewChild('txtqty023_sp') txtqty023_sp: any;
  @ViewChild('txtmin023') txtmin023: any;
  @ViewChild('txttotal023') txttotal023: any;
  v_total023: number = 0;
  @ViewChild('txtqty024') txtqty024: any; @ViewChild('txtqty024_sp') txtqty024_sp: any;
  @ViewChild('txtmin024') txtmin024: any;
  @ViewChild('txttotal024') txttotal024: any;
  v_total024: number = 0;
  @ViewChild('txtqty025') txtqty025: any; @ViewChild('txtqty025_sp') txtqty025_sp: any;
  @ViewChild('txtmin025') txtmin025: any;
  @ViewChild('txttotal025') txttotal025: any;
  v_total025: number = 0;
  @ViewChild('txtqty026') txtqty026: any; @ViewChild('txtqty026_sp') txtqty026_sp: any;
  @ViewChild('txtmin026') txtmin026: any;
  @ViewChild('txttotal026') txttotal026: any;
  v_total026: number = 0;

  @ViewChild('txtqty03') txtqty03: any; @ViewChild('txtqty03_sp') txtqty03_sp: any;
  @ViewChild('txtmin03') txtmin03: any;
  @ViewChild('txttotal03') txttotal03: any;
  v_total03: number = 0;
  @ViewChild('txtqty04') txtqty04: any; @ViewChild('txtqty04_sp') txtqty04_sp: any;
  @ViewChild('txtmin04') txtmin04: any;
  @ViewChild('txttotal04') txttotal04: any;
  v_total04: number = 0;

  @ViewChild('txttotal_overtime') txttotal_overtime: any;
  v_total_overtime: number = 0;
  serv: any = [];
  get_service_search: any;
  items: any = [];
  overtime_01: number = 0; overtime_01_sp: number = 0; overtime_01_op: number = 0;
  overtime_02: number = 0; overtime_02_sp: number = 0; overtime_02_op: number = 0;
  overtime_03: number = 0; overtime_03_sp: number = 0; overtime_03_op: number = 0;
  overtime_04: number = 0; overtime_04_sp: number = 0; overtime_04_op: number = 0;

  constructor(
    private ServiceJksService: ServiceJksService
  ) { }

  onKeyqty011(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin011.nativeElement.value = "60";
      this.v_total011 = (parseInt(event.target.value) + parseInt(this.txtqty011_sp.nativeElement.value)) * parseInt(this.txtmin011.nativeElement.value);
      this.v_total_overtime = this.v_total011
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = this.v_total011
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = parseInt(event.target.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    } else {
      this.v_total011 = (0 + parseInt(this.txtqty011_sp.nativeElement.value)) * parseInt(this.txtmin011.nativeElement.value);
      this.v_total_overtime = 0
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = 0
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = 0
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    }
    this.serv = {
      "header": "overtime01",
      "value": this.overtime_01,
      "header_op": "overtime01_op",
      "value_op": this.overtime_01_op,
      "header_sp": "overtime01_sp",
      "value_sp": this.overtime_01_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }
  onKeyqty011_sp(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin011.nativeElement.value = "60";
      this.v_total011 = (parseInt(event.target.value) + parseInt(this.txtqty011.nativeElement.value)) * parseInt(this.txtmin011.nativeElement.value);
      this.v_total_overtime = this.v_total011
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = this.v_total011
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = parseInt(event.target.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    } else {
      this.v_total011 = (0 + parseInt(this.txtqty011.nativeElement.value)) * parseInt(this.txtmin011.nativeElement.value);
      this.v_total_overtime = 0
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = 0
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = 0
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    }
    this.serv = {
      "header": "overtime01",
      "value": this.overtime_01,
      "header_op": "overtime01_op",
      "value_op": this.overtime_01_op,
      "header_sp": "overtime01_sp",
      "value_sp": this.overtime_01_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  onKeyqty012(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin012.nativeElement.value = "120";
      this.v_total012 = (parseInt(event.target.value) + parseInt(this.txtqty012_sp.nativeElement.value)) * parseInt(this.txtmin012.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + this.v_total012
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + this.v_total012
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(event.target.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    } else {
      this.v_total012 = (0 + parseInt(this.txtqty012_sp.nativeElement.value)) * parseInt(this.txtmin012.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + 0
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    }
    this.serv = {
      "header": "overtime01",
      "value": this.overtime_01,
      "header_op": "overtime01_op",
      "value_op": this.overtime_01_op,
      "header_sp": "overtime01_sp",
      "value_sp": this.overtime_01_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }
  onKeyqty012_sp(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin012.nativeElement.value = "120";
      this.v_total012 = (parseInt(event.target.value) + parseInt(this.txtqty012.nativeElement.value)) * parseInt(this.txtmin012.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + this.v_total012
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + this.v_total012
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(event.target.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    } else {
      this.v_total012 = (0 + parseInt(this.txtqty012.nativeElement.value)) * parseInt(this.txtmin012.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + 0
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    }
    this.serv = {
      "header": "overtime01",
      "value": this.overtime_01,
      "header_op": "overtime01_op",
      "value_op": this.overtime_01_op,
      "header_sp": "overtime01_sp",
      "value_sp": this.overtime_01_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  onKeyqty013(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin013.nativeElement.value = "150";
      this.v_total013 = (parseInt(event.target.value) + parseInt(this.txtqty013_sp.nativeElement.value)) * parseInt(this.txtmin013.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + this.v_total013
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + this.v_total013
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(event.target.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    } else {
      this.v_total013 = (0 + parseInt(this.txtqty013_sp.nativeElement.value)) * parseInt(this.txtmin013.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + 0
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    }
    this.serv = {
      "header": "overtime01",
      "value": this.overtime_01,
      "header_op": "overtime01_op",
      "value_op": this.overtime_01_op,
      "header_sp": "overtime01_sp",
      "value_sp": this.overtime_01_sp
    };

    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }
  onKeyqty013_sp(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin013.nativeElement.value = "150";
      this.v_total013 = (parseInt(event.target.value) + parseInt(this.txtqty013.nativeElement.value)) * parseInt(this.txtmin013.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + this.v_total013
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + this.v_total013
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(event.target.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    } else {
      this.v_total013 = (0 + parseInt(this.txtqty013.nativeElement.value)) * parseInt(this.txtmin013.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value));

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + 0
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(this.txtmin014.nativeElement.value);
    }
    this.serv = {
      "header": "overtime01",
      "value": this.overtime_01,
      "header_op": "overtime01_op",
      "value_op": this.overtime_01_op,
      "header_sp": "overtime01_sp",
      "value_sp": this.overtime_01_sp
    };

    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  onKeyqty014(event: any) {
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txtmin014.nativeElement.value))) {
      this.v_total014 = (parseInt(event.target.value) + parseInt(this.txtqty014_sp.nativeElement.value)) * parseInt(this.txtmin014.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + this.v_total014
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

    } else {
      this.v_total014 = (0 + parseInt(this.txtqty014_sp.nativeElement.value)) * parseInt(this.txtmin014.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    }
  }
  onKeyqty014_sp(event: any) {
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txtmin014.nativeElement.value))) {
      this.v_total014 = (parseInt(event.target.value) + parseInt(this.txtqty014.nativeElement.value)) * parseInt(this.txtmin014.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + this.v_total014
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

    } else {
      this.v_total014 = (0 + parseInt(this.txtqty014.nativeElement.value)) * parseInt(this.txtmin014.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    }
  }
  onKeyqty014_2(event: any) {
    if (!isNaN(parseInt(this.txtqty014.nativeElement.value) * parseInt(event.target.value))) {
      this.v_total014 = (parseInt(this.txtqty014.nativeElement.value) + parseInt(this.txtqty014_sp.nativeElement.value)) * parseInt(event.target.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + this.v_total014
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + this.v_total014;

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014.nativeElement.value) * parseInt(event.target.value);

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + parseInt(this.txtqty014_sp.nativeElement.value) * parseInt(event.target.value);
    } else {
      this.v_total014 = (parseInt(this.txtqty014.nativeElement.value) + parseInt(this.txtqty014_sp.nativeElement.value)) * 0;
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_01 = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + 0;

      this.overtime_01_op = parseInt(this.txtqty011.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + 0;

      this.overtime_01_sp = parseInt(this.txtqty011_sp.nativeElement.value) * parseInt(this.txtmin011.nativeElement.value)
        + parseInt(this.txtqty012_sp.nativeElement.value) * parseInt(this.txtmin012.nativeElement.value)
        + parseInt(this.txtqty013_sp.nativeElement.value) * parseInt(this.txtmin013.nativeElement.value)
        + 0;
    }
    this.serv = {
      "header": "overtime01",
      "value": this.overtime_01,
      "header_op": "overtime01_op",
      "value_op": this.overtime_01_op,
      "header_sp": "overtime01_sp",
      "value_sp": this.overtime_01_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  onKeyqty021(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin021.nativeElement.value = "30";
      this.v_total021 = (parseInt(event.target.value) + parseInt(this.txtqty021_sp.nativeElement.value)) * parseInt(this.txtmin021.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + this.v_total021
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = this.v_total021
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(event.target.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    } else {
      this.v_total021 = (0 + parseInt(this.txtqty021_sp.nativeElement.value)) * parseInt(this.txtmin021.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = 0
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = 0
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    }
    this.serv = {
      "header": "overtime02",
      "value": this.overtime_02,
      "header_op": "overtime02_op",
      "value_op": this.overtime_02_op,
      "header_sp": "overtime02_sp",
      "value_sp": this.overtime_02_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }
  onKeyqty021_sp(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin021.nativeElement.value = "30";
      this.v_total021 = (parseInt(event.target.value) + parseInt(this.txtqty021.nativeElement.value)) * parseInt(this.txtmin021.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + this.v_total021
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = this.v_total021
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(event.target.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    } else {
      this.v_total021 = (0 + parseInt(this.txtqty021.nativeElement.value)) * parseInt(this.txtmin021.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = 0
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + 0
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    }
    this.serv = {
      "header": "overtime02",
      "value": this.overtime_02,
      "header_op": "overtime02_op",
      "value_op": this.overtime_02_op,
      "header_sp": "overtime02_sp",
      "value_sp": this.overtime_02_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  onKeyqty022(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin022.nativeElement.value = "60";
      this.v_total022 = (parseInt(event.target.value) + parseInt(this.txtqty022_sp.nativeElement.value)) * parseInt(this.txtmin022.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + this.v_total022
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + this.v_total022
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(event.target.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    } else {
      this.v_total022 = (0 + parseInt(this.txtqty022_sp.nativeElement.value)) * parseInt(this.txtmin022.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + 0
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    }
    this.serv = {
      "header": "overtime02",
      "value": this.overtime_02,
      "header_op": "overtime02_op",
      "value_op": this.overtime_02_op,
      "header_sp": "overtime02_sp",
      "value_sp": this.overtime_02_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }
  onKeyqty022_sp(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin022.nativeElement.value = "60";
      this.v_total022 = (parseInt(event.target.value) + parseInt(this.txtqty022.nativeElement.value)) * parseInt(this.txtmin022.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + this.v_total022
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + this.v_total022
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(event.target.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    } else {
      this.v_total022 = (0 + parseInt(this.txtqty022.nativeElement.value)) * parseInt(this.txtmin022.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + 0
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    }
    this.serv = {
      "header": "overtime02",
      "value": this.overtime_02,
      "header_op": "overtime02_op",
      "value_op": this.overtime_02_op,
      "header_sp": "overtime02_sp",
      "value_sp": this.overtime_02_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  onKeyqty023(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin023.nativeElement.value = "90";
      this.v_total023 = (parseInt(event.target.value) + parseInt(this.txtqty023_sp.nativeElement.value)) * parseInt(this.txtmin023.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + this.v_total023
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + this.v_total023
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(event.target.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    } else {
      this.v_total023 = (0 + parseInt(this.txtqty023_sp.nativeElement.value)) * parseInt(this.txtmin023.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + 0
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    }
    this.serv = {
      "header": "overtime02",
      "value": this.overtime_02,
      "header_op": "overtime02_op",
      "value_op": this.overtime_02_op,
      "header_sp": "overtime02_sp",
      "value_sp": this.overtime_02_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }
  onKeyqty023_sp(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin023.nativeElement.value = "90";
      this.v_total023 = (parseInt(event.target.value) + parseInt(this.txtqty023.nativeElement.value)) * parseInt(this.txtmin023.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + this.v_total023
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + this.v_total023
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(event.target.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    } else {
      this.v_total023 = (0 + parseInt(this.txtqty023.nativeElement.value)) * parseInt(this.txtmin023.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + 0
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    }
    this.serv = {
      "header": "overtime02",
      "value": this.overtime_02,
      "header_op": "overtime02_op",
      "value_op": this.overtime_02_op,
      "header_sp": "overtime02_sp",
      "value_sp": this.overtime_02_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  onKeyqty024(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin024.nativeElement.value = "120";
      this.v_total024 = (parseInt(event.target.value) + parseInt(this.txtqty024_sp.nativeElement.value)) * parseInt(this.txtmin024.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + this.v_total024
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + this.v_total024
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(event.target.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    } else {
      this.v_total024 = (0 + parseInt(this.txtqty024_sp.nativeElement.value)) * parseInt(this.txtmin024.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + 0
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    }
    this.serv = {
      "header": "overtime02",
      "value": this.overtime_02,
      "header_op": "overtime02_op",
      "value_op": this.overtime_02_op,
      "header_sp": "overtime02_sp",
      "value_sp": this.overtime_02_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }
  onKeyqty024_sp(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.txtmin024.nativeElement.value = "120";
      this.v_total024 = (parseInt(event.target.value) + parseInt(this.txtqty024.nativeElement.value)) * parseInt(this.txtmin024.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + this.v_total024
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + this.v_total024
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(event.target.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    } else {
      this.v_total024 = (0 + parseInt(this.txtqty024.nativeElement.value)) * parseInt(this.txtmin024.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + 0
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    }
    this.serv = {
      "header": "overtime02",
      "value": this.overtime_02,
      "header_op": "overtime02_op",
      "value_op": this.overtime_02_op,
      "header_sp": "overtime02_sp",
      "value_sp": this.overtime_02_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  onKeyqty025(event: any) {
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txtmin025.nativeElement.value))) {
      this.v_total025 = (parseInt(event.target.value) + parseInt(this.txtqty025_sp.nativeElement.value)) * parseInt(this.txtmin025.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + this.v_total025
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    } else {
      this.v_total025 = (0 + parseInt(this.txtqty025_sp.nativeElement.value)) * parseInt(this.txtmin025.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    }
  }
  onKeyqty025_sp(event: any) {
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txtmin025.nativeElement.value))) {
      this.v_total025 = (parseInt(event.target.value) + parseInt(this.txtqty025.nativeElement.value)) * parseInt(this.txtmin025.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + this.v_total025
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    } else {
      this.v_total025 = (0 + parseInt(this.txtqty025.nativeElement.value)) * parseInt(this.txtmin025.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    }
  }
  onKeyqty025_2(event: any) {
    if (!isNaN(parseInt(this.txtqty025.nativeElement.value) * parseInt(event.target.value))) {
      this.v_total025 = (parseInt(this.txtqty025.nativeElement.value) + parseInt(this.txtqty025_sp.nativeElement.value)) * parseInt(event.target.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + this.v_total025
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + this.v_total025
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(event.target.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(event.target.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    } else {
      this.v_total025 = (parseInt(this.txtqty025.nativeElement.value) + parseInt(this.txtqty025_sp.nativeElement.value)) * 0;
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value));

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * 0
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * 0
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(this.txtmin026.nativeElement.value);
    }
    this.serv = {
      "header": "overtime02",
      "value": this.overtime_02,
      "header_op": "overtime02_op",
      "value_op": this.overtime_02_op,
      "header_sp": "overtime02_sp",
      "value_sp": this.overtime_02_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  onKeyqty026(event: any) {
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txtmin026.nativeElement.value))) {
      this.v_total026 = (parseInt(event.target.value) + parseInt(this.txtqty026_sp.nativeElement.value)) * parseInt(this.txtmin026.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + this.v_total026
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    } else {
      this.v_total026 = (0 + parseInt(this.txtqty026_sp.nativeElement.value)) * parseInt(this.txtmin026.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    }
  }
  onKeyqty026_sp(event: any) {
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txtmin026.nativeElement.value))) {
      this.v_total026 = (parseInt(event.target.value) + parseInt(this.txtqty026.nativeElement.value)) * parseInt(this.txtmin026.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + this.v_total026
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    } else {
      this.v_total026 = (0 + parseInt(this.txtqty026.nativeElement.value)) * parseInt(this.txtmin026.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    }
  }
  onKeyqty026_2(event: any) {
    if (!isNaN(parseInt(this.txtqty026.nativeElement.value) * parseInt(event.target.value))) {
      this.v_total026 = (parseInt(this.txtqty026.nativeElement.value) + parseInt(this.txtqty026_sp.nativeElement.value)) * parseInt(event.target.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + this.v_total026
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + this.v_total026;

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * parseInt(event.target.value) ;

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * parseInt(event.target.value) ;
    } else {
      this.v_total026 = (parseInt(this.txtqty026.nativeElement.value) + parseInt(this.txtqty026_sp.nativeElement.value)) * 0;
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_02 = (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + 0;

      this.overtime_02_op = parseInt(this.txtqty021.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026.nativeElement.value) * 0;

      this.overtime_02_sp = parseInt(this.txtqty021_sp.nativeElement.value) * parseInt(this.txtmin021.nativeElement.value)
        + parseInt(this.txtqty022_sp.nativeElement.value) * parseInt(this.txtmin022.nativeElement.value)
        + parseInt(this.txtqty023_sp.nativeElement.value) * parseInt(this.txtmin023.nativeElement.value)
        + parseInt(this.txtqty024_sp.nativeElement.value) * parseInt(this.txtmin024.nativeElement.value)
        + parseInt(this.txtqty025_sp.nativeElement.value) * parseInt(this.txtmin025.nativeElement.value)
        + parseInt(this.txtqty026_sp.nativeElement.value) * 0;
    }
    this.serv = {
      "header": "overtime02",
      "value": this.overtime_02,
      "header_op": "overtime02_op",
      "value_op": this.overtime_02_op,
      "header_sp": "overtime02_sp",
      "value_sp": this.overtime_02_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  onKeyqty03(event: any) {
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txtmin03.nativeElement.value))) {
      this.v_total03 = (parseInt(event.target.value) + parseInt(this.txtqty03_sp.nativeElement.value)) * parseInt(this.txtmin03.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + this.v_total03
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    } else {
      this.v_total03 = (0 + parseInt(this.txtqty03_sp.nativeElement.value)) * parseInt(this.txtmin03.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    }
  }
  onKeyqty03_sp(event: any) {
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txtmin03.nativeElement.value))) {
      this.v_total03 = (parseInt(event.target.value) + parseInt(this.txtqty03.nativeElement.value)) * parseInt(this.txtmin03.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + this.v_total03
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    } else {
      this.v_total03 = (0 + parseInt(this.txtqty03.nativeElement.value)) * parseInt(this.txtmin03.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));
    }
  }
  onKeyqty03_2(event: any) {
    if (!isNaN(parseInt(this.txtqty03.nativeElement.value) * parseInt(event.target.value))) {
      this.v_total03 = (parseInt(this.txtqty03.nativeElement.value) + parseInt(this.txtqty03_sp.nativeElement.value)) * parseInt(event.target.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + this.v_total03
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_03 = this.v_total03;
      this.overtime_03_op = parseInt(this.txtqty03.nativeElement.value) * parseInt(event.target.value);
      this.overtime_03_sp = parseInt(this.txtqty03_sp.nativeElement.value) * parseInt(event.target.value);
    } else {
      this.v_total03 = (parseInt(this.txtqty03.nativeElement.value) + parseInt(this.txtqty03_sp.nativeElement.value)) * 0;
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + 0
        + (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value));

      this.overtime_03 = 0;
      this.overtime_03_op = 0;
      this.overtime_03_sp = 0;
    }
    this.serv = {
      "header": "overtime03",
      "value": this.overtime_03,
      "header_op": "overtime03_op",
      "value_op": this.overtime_03_op,
      "header_sp": "overtime03_sp",
      "value_sp": this.overtime_03_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  onKeyqty04(event: any) {
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txtmin04.nativeElement.value))) {
      this.v_total04 = (parseInt(event.target.value) + parseInt(this.txtqty04_sp.nativeElement.value)) * parseInt(this.txtmin04.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + this.v_total04;
    } else {
      this.v_total04 = (0 + parseInt(this.txtqty04_sp.nativeElement.value)) * parseInt(this.txtmin04.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + 0;
    }
  }
  onKeyqty04_sp(event: any) {
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txtmin04.nativeElement.value))) {
      this.v_total04 = (parseInt(event.target.value) + parseInt(this.txtqty04.nativeElement.value)) * parseInt(this.txtmin04.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + this.v_total04;
    } else {
      this.v_total04 = (0 + parseInt(this.txtqty04.nativeElement.value)) * parseInt(this.txtmin04.nativeElement.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + 0;
    }
  }
  onKeyqty04_2(event: any) {
    if (!isNaN(parseInt(this.txtqty04.nativeElement.value) * parseInt(event.target.value))) {
      this.v_total04 = (parseInt(this.txtqty04.nativeElement.value) + parseInt(this.txtqty04_sp.nativeElement.value)) * parseInt(event.target.value);
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + this.v_total04;

      this.overtime_04 = this.v_total04;
      this.overtime_04_op = parseInt(this.txtqty04.nativeElement.value) * parseInt(event.target.value);
      this.overtime_04_sp = parseInt(this.txtqty04_sp.nativeElement.value) * parseInt(event.target.value);
    } else {
      this.v_total04 = (parseInt(this.txtqty04.nativeElement.value) + parseInt(this.txtqty04_sp.nativeElement.value)) * 0;
      this.v_total_overtime = (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value))
        + (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value))
        + (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value))
        + (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value))
        + (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value))
        + (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value))
        + (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value))
        + (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value))
        + (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value))
        + (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value))
        + (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value))
        + 0;

      this.overtime_04 = 0;
      this.overtime_04_op = 0;
      this.overtime_04_sp = 0;
    }    
    this.serv = {
      "header": "overtime04",
      "value": this.overtime_04,
      "header_op": "overtime04_op",
      "value_op": this.overtime_04_op,
      "header_sp": "overtime04_sp",
      "value_sp": this.overtime_04_sp
    };
    this.ServiceJksService.addovertime(this.serv);

    this.services();
  }

  ngOnInit(): void {
    this.v_total011 = 0;
  }

  total: number = 0;

  get_serviceov: any;
  qty011: number = 0; qty011_sp: number = 0;
  qty012: number = 0; qty012_sp: number = 0;
  qty013: number = 0; qty013_sp: number = 0;
  qty014: number = 0; qty014_sp: number = 0; min014: number = 0;
  qty021: number = 0; qty021_sp: number = 0;
  qty022: number = 0; qty022_sp: number = 0;
  qty023: number = 0; qty023_sp: number = 0;
  qty024: number = 0; qty024_sp: number = 0;
  qty025: number = 0; qty025_sp: number = 0; min025: number = 0;
  qty026: number = 0; qty026_sp: number = 0; min026: number = 0;
  qty03: number = 0; qty03_sp: number = 0; min03: number = 0;
  qty04: number = 0; qty04_sp: number = 0; min04: number = 0;

  check_overtime: number = 0;
  ngDoCheck() {
    this.items = this.ServiceJksService.getservice_search();
    if (this.items.length > 0) {
      // console.log('items: ', this.items)
      // console.log('total_overtime: ', this.items[0].total_overtime)
      this.total = this.items[0].total_overtime === undefined ? 0 : this.items[0].total_overtime;
      // console.log('this.total: ', this.total)

      // console.log('this.v_total_overtime: ', this.v_total_overtime)
      // console.log('this.items[0].check_overtime: ', this.items[0].check_overtime)
      // console.log('check_overtime: ', this.check_overtime)

      if (this.check_overtime === 0) {
        // console.log('==')
        this.check_overtime = this.items[0].check_overtime;
      } else {

        if (this.check_overtime === this.items[0].check_overtime) {
          // console.log('this.services')  //กรณีที่ค้นหา แล้วมีการกรอก OT (มีการอัปเดตตลอดเวลา)
          this.services();
        } else {
          // console.log('this.services')  //กรณีที่ค้นหา แล้วมีการกรอก OT (มีการอัปเดตตลอดเวลา)
          this.services();
        }
      }
    }
  }

  services() {
    const sv = {
      "ot_60_qty": (isNaN(parseInt(this.txtqty011.nativeElement.value)) ? 0 : parseInt(this.txtqty011.nativeElement.value)),
      "ot_60_qty_sp": (isNaN(parseInt(this.txtqty011_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty011_sp.nativeElement.value)),
      "ot_60_total": (isNaN(parseInt(this.txttotal011.nativeElement.value)) ? 0 : parseInt(this.txttotal011.nativeElement.value)),
      "ot_120_qty": (isNaN(parseInt(this.txtqty012.nativeElement.value)) ? 0 : parseInt(this.txtqty012.nativeElement.value)),
      "ot_120_qty_sp": (isNaN(parseInt(this.txtqty012_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty012_sp.nativeElement.value)),
      "ot_120_total": (isNaN(parseInt(this.txttotal012.nativeElement.value)) ? 0 : parseInt(this.txttotal012.nativeElement.value)),
      "ot_150_qty": (isNaN(parseInt(this.txtqty013.nativeElement.value)) ? 0 : parseInt(this.txtqty013.nativeElement.value)),
      "ot_150_qty_sp": (isNaN(parseInt(this.txtqty013_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty013_sp.nativeElement.value)),
      "ot_150_total": (isNaN(parseInt(this.txttotal013.nativeElement.value)) ? 0 : parseInt(this.txttotal013.nativeElement.value)),
      "ot_other_qty": (isNaN(parseInt(this.txtqty014.nativeElement.value)) ? 0 : parseInt(this.txtqty014.nativeElement.value)),
      "ot_other_qty_sp": (isNaN(parseInt(this.txtqty014_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty014_sp.nativeElement.value)),
      "ot_other_min": (isNaN(parseInt(this.txtmin014.nativeElement.value)) ? 0 : parseInt(this.txtmin014.nativeElement.value)),
      "ot_other_total": (isNaN(parseInt(this.txttotal014.nativeElement.value)) ? 0 : parseInt(this.txttotal014.nativeElement.value)),
      "clinic_30_qty": (isNaN(parseInt(this.txtqty021.nativeElement.value)) ? 0 : parseInt(this.txtqty021.nativeElement.value)),
      "clinic_30_qty_sp": (isNaN(parseInt(this.txtqty021_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty021_sp.nativeElement.value)),
      "clinic_30_total": (isNaN(parseInt(this.txttotal021.nativeElement.value)) ? 0 : parseInt(this.txttotal021.nativeElement.value)),
      "clinic_60_qty": (isNaN(parseInt(this.txtqty022.nativeElement.value)) ? 0 : parseInt(this.txtqty022.nativeElement.value)),
      "clinic_60_qty_sp": (isNaN(parseInt(this.txtqty022_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty022_sp.nativeElement.value)),
      "clinic_60_total": (isNaN(parseInt(this.txttotal022.nativeElement.value)) ? 0 : parseInt(this.txttotal022.nativeElement.value)),
      "clinic_90_qty": (isNaN(parseInt(this.txtqty023.nativeElement.value)) ? 0 : parseInt(this.txtqty023.nativeElement.value)),
      "clinic_90_qty_sp": (isNaN(parseInt(this.txtqty023_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty023_sp.nativeElement.value)),
      "clinic_90_total": (isNaN(parseInt(this.txttotal023.nativeElement.value)) ? 0 : parseInt(this.txttotal023.nativeElement.value)),
      "clinic_120_qty": (isNaN(parseInt(this.txtqty024.nativeElement.value)) ? 0 : parseInt(this.txtqty024.nativeElement.value)),
      "clinic_120_qty_sp": (isNaN(parseInt(this.txtqty024_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty024_sp.nativeElement.value)),
      "clinic_120_total": (isNaN(parseInt(this.txttotal024.nativeElement.value)) ? 0 : parseInt(this.txttotal024.nativeElement.value)),
      "clinic_other_qty": (isNaN(parseInt(this.txtqty025.nativeElement.value)) ? 0 : parseInt(this.txtqty025.nativeElement.value)),
      "clinic_other_qty_sp": (isNaN(parseInt(this.txtqty025_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty025_sp.nativeElement.value)),
      "clinic_other_min": (isNaN(parseInt(this.txtmin025.nativeElement.value)) ? 0 : parseInt(this.txtmin025.nativeElement.value)),
      "clinic_other_total": (isNaN(parseInt(this.txttotal025.nativeElement.value)) ? 0 : parseInt(this.txttotal025.nativeElement.value)),
      "leave_halfe_qty": (isNaN(parseInt(this.txtqty026.nativeElement.value)) ? 0 : parseInt(this.txtqty026.nativeElement.value)),
      "leave_halfe_qty_sp": (isNaN(parseInt(this.txtqty026_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty026_sp.nativeElement.value)),
      "leave_halfe_min": (isNaN(parseInt(this.txtmin026.nativeElement.value)) ? 0 : parseInt(this.txtmin026.nativeElement.value)),
      "leave_halfe_total": (isNaN(parseInt(this.txttotal026.nativeElement.value)) ? 0 : parseInt(this.txttotal026.nativeElement.value)),
      "out_flow_qty": (isNaN(parseInt(this.txtqty03.nativeElement.value)) ? 0 : parseInt(this.txtqty03.nativeElement.value)),
      "out_flow_qty_sp": (isNaN(parseInt(this.txtqty03_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty03_sp.nativeElement.value)),
      "out_flow_min": (isNaN(parseInt(this.txtmin03.nativeElement.value)) ? 0 : parseInt(this.txtmin03.nativeElement.value)),
      "out_flow_total": (isNaN(parseInt(this.txttotal03.nativeElement.value)) ? 0 : parseInt(this.txttotal03.nativeElement.value)),
      "in_flow_qty": (isNaN(parseInt(this.txtqty04.nativeElement.value)) ? 0 : parseInt(this.txtqty04.nativeElement.value)),
      "in_flow_qty_sp": (isNaN(parseInt(this.txtqty04_sp.nativeElement.value)) ? 0 : parseInt(this.txtqty04_sp.nativeElement.value)),
      "in_flow_min": (isNaN(parseInt(this.txtmin04.nativeElement.value)) ? 0 : parseInt(this.txtmin04.nativeElement.value)),
      "in_flow_total": (isNaN(parseInt(this.txttotal04.nativeElement.value)) ? 0 : parseInt(this.txttotal04.nativeElement.value)),
      "total_overtime": isNaN(parseInt(this.txttotal_overtime.nativeElement.value)) ? 0 : parseInt(this.txttotal_overtime.nativeElement.value),
    }
    // console.log(sv)
    this.ServiceJksService.sv_over(sv);
  }
  services2() {
    const sv = {
      "ot_60_qty": this.items[0].ot_60_qty === undefined ? 0 : this.items[0].ot_60_qty,
      "ot_60_qty_sp": this.items[0].ot_60_qty_sp === undefined ? 0 : this.items[0].ot_60_qty_sp,
      "ot_60_total": this.items[0].ot_60_total === undefined ? 0 : this.items[0].ot_60_total,
      "ot_120_qty": this.items[0].ot_120_qty === undefined ? 0 : this.items[0].ot_120_qty,
      "ot_120_qty_sp": this.items[0].ot_120_qty_sp === undefined ? 0 : this.items[0].ot_120_qty_sp,
      "ot_120_total": this.items[0].ot_120_total === undefined ? 0 : this.items[0].ot_120_total,
      "ot_150_qty": this.items[0].ot_150_qty === undefined ? 0 : this.items[0].ot_150_qty,
      "ot_150_qty_sp": this.items[0].ot_150_qty_sp === undefined ? 0 : this.items[0].ot_150_qty_sp,
      "ot_150_total": this.items[0].ot_150_total === undefined ? 0 : this.items[0].ot_150_total,
      "ot_other_qty": this.items[0].ot_other_qty === undefined ? 0 : this.items[0].ot_other_qty,
      "ot_other_qty_sp": this.items[0].ot_other_qty_sp === undefined ? 0 : this.items[0].ot_other_qty_sp,
      "ot_other_min": this.items[0].ot_other_min === undefined ? 0 : this.items[0].ot_other_min,
      "ot_other_total": this.items[0].ot_other_total === undefined ? 0 : this.items[0].ot_other_total,
      "clinic_30_qty": this.items[0].clinic_30_qty === undefined ? 0 : this.items[0].clinic_30_qty,
      "clinic_30_qty_sp": this.items[0].clinic_30_qty_sp === undefined ? 0 : this.items[0].clinic_30_qty_sp,
      "clinic_30_total": this.items[0].clinic_30_total === undefined ? 0 : this.items[0].clinic_30_total,
      "clinic_60_qty": this.items[0].clinic_60_qty === undefined ? 0 : this.items[0].clinic_60_qty,
      "clinic_60_qty_sp": this.items[0].clinic_60_qty_sp === undefined ? 0 : this.items[0].clinic_60_qty_sp,
      "clinic_60_total": this.items[0].clinic_60_total === undefined ? 0 : this.items[0].clinic_60_total,
      "clinic_90_qty": this.items[0].clinic_90_qty === undefined ? 0 : this.items[0].clinic_90_qty,
      "clinic_90_qty_sp": this.items[0].clinic_90_qty_sp === undefined ? 0 : this.items[0].clinic_90_qty,
      "clinic_90_total": this.items[0].clinic_90_total === undefined ? 0 : this.items[0].clinic_90_total,
      "clinic_120_qty": this.items[0].clinic_120_qty === undefined ? 0 : this.items[0].clinic_120_qty,
      "clinic_120_qty_sp": this.items[0].clinic_120_qty_sp === undefined ? 0 : this.items[0].clinic_120_qty_sp,
      "clinic_120_total": this.items[0].clinic_120_total === undefined ? 0 : this.items[0].clinic_120_total,
      "clinic_other_qty": this.items[0].clinic_other_qty === undefined ? 0 : this.items[0].clinic_other_qty,
      "clinic_other_qty_sp": this.items[0].clinic_other_qty_sp === undefined ? 0 : this.items[0].clinic_other_qty_sp,
      "clinic_other_min": this.items[0].clinic_other_min === undefined ? 0 : this.items[0].clinic_other_min,
      "clinic_other_total": this.items[0].clinic_other_total === undefined ? 0 : this.items[0].clinic_other_total,
      "leave_halfe_qty": this.items[0].leave_halfe_qty === undefined ? 0 : this.items[0].leave_halfe_qty,
      "leave_halfe_qty_sp": this.items[0].leave_halfe_qty_sp === undefined ? 0 : this.items[0].leave_halfe_qty_sp,
      "leave_halfe_min": this.items[0].leave_halfe_min === undefined ? 0 : this.items[0].leave_halfe_min,
      "leave_halfe_total": this.items[0].leave_halfe_total === undefined ? 0 : this.items[0].leave_halfe_total,
      "out_flow_qty": this.items[0].out_flow_qty === undefined ? 0 : this.items[0].out_flow_qty,
      "out_flow_qty_sp": this.items[0].out_flow_qty_sp === undefined ? 0 : this.items[0].out_flow_qty_sp,
      "out_flow_min": this.items[0].out_flow_min === undefined ? 0 : this.items[0].out_flow_min,
      "out_flow_total": this.items[0].out_flow_total === undefined ? 0 : this.items[0].out_flow_total,
      "in_flow_qty": this.items[0].in_flow_qty === undefined ? 0 : this.items[0].in_flow_qty,
      "in_flow_qty_sp": this.items[0].in_flow_qty_sp === undefined ? 0 : this.items[0].in_flow_qty_sp,
      "in_flow_min": this.items[0].in_flow_min === undefined ? 0 : this.items[0].in_flow_min,
      "in_flow_total": this.items[0].in_flow_total === undefined ? 0 : this.items[0].in_flow_total,
      "total_overtime": this.items[0].total_overtime === undefined ? 0 : this.items[0].total_overtime,
    }
    this.ServiceJksService.sv_over(sv);
  }
  services3() {
    this.qty011 = this.items[0].ot_60_qty === undefined ? 0 : this.items[0].ot_60_qty;
    this.qty011_sp = this.items[0].ot_60_qty_sp === undefined ? 0 : this.items[0].ot_60_qty_sp;
    this.v_total011 = this.items[0].ot_60_total === undefined ? 0 : this.items[0].ot_60_total;
    this.qty012 = this.items[0].ot_120_qty === undefined ? 0 : this.items[0].ot_120_qty;
    this.qty012_sp = this.items[0].ot_120_qty_sp === undefined ? 0 : this.items[0].ot_120_qty_sp;
    this.v_total012 = this.items[0].ot_120_total === undefined ? 0 : this.items[0].ot_120_total;
    this.qty013 = this.items[0].ot_150_qty === undefined ? 0 : this.items[0].ot_150_qty;
    this.qty013_sp = this.items[0].ot_150_qty_sp === undefined ? 0 : this.items[0].ot_150_qty_sp;
    this.v_total013 = this.items[0].ot_150_total === undefined ? 0 : this.items[0].ot_150_total;
    this.qty014 = this.items[0].ot_other_qty === undefined ? 0 : this.items[0].ot_other_qty;
    this.qty014_sp = this.items[0].ot_other_qty_sp === undefined ? 0 : this.items[0].ot_other_qty_sp;
    this.min014 = this.items[0].ot_other_min === undefined ? 0 : this.items[0].ot_other_min;
    this.v_total014 = this.items[0].ot_other_total === undefined ? 0 : this.items[0].ot_other_total;
    this.qty021 = this.items[0].clinic_30_qty === undefined ? 0 : this.items[0].clinic_30_qty;
    this.qty021_sp = this.items[0].clinic_30_qty_sp === undefined ? 0 : this.items[0].clinic_30_qty_sp;
    this.v_total021 = this.items[0].clinic_30_total === undefined ? 0 : this.items[0].clinic_30_total;
    this.qty022 = this.items[0].clinic_60_qty === undefined ? 0 : this.items[0].clinic_60_qty;
    this.qty022_sp = this.items[0].clinic_60_qty_sp === undefined ? 0 : this.items[0].clinic_60_qty_sp;
    this.v_total022 = this.items[0].clinic_60_total === undefined ? 0 : this.items[0].clinic_60_total;
    this.qty023 = this.items[0].clinic_90_qty === undefined ? 0 : this.items[0].clinic_90_qty;
    this.qty023_sp = this.items[0].clinic_90_qty_sp === undefined ? 0 : this.items[0].clinic_90_qty_sp;
    this.v_total023 = this.items[0].clinic_90_total === undefined ? 0 : this.items[0].clinic_90_total;
    this.qty024 = this.items[0].clinic_120_qty === undefined ? 0 : this.items[0].clinic_120_qty;
    this.qty024_sp = this.items[0].clinic_120_qty_sp === undefined ? 0 : this.items[0].clinic_120_qty_sp;
    this.v_total024 = this.items[0].clinic_120_total === undefined ? 0 : this.items[0].clinic_120_total;
    this.qty025 = this.items[0].clinic_other_qty === undefined ? 0 : this.items[0].clinic_other_qty;
    this.qty025_sp = this.items[0].clinic_other_qty_sp === undefined ? 0 : this.items[0].clinic_other_qty_sp;
    this.min025 = this.items[0].clinic_other_min === undefined ? 0 : this.items[0].clinic_other_min;
    this.v_total025 = this.items[0].clinic_other_total === undefined ? 0 : this.items[0].clinic_other_total;
    this.qty026 = this.items[0].leave_halfe_qty === undefined ? 0 : this.items[0].leave_halfe_qty;
    this.qty026_sp = this.items[0].leave_halfe_qty_sp === undefined ? 0 : this.items[0].leave_halfe_qty_sp;
    this.min026 = this.items[0].leave_halfe_min === undefined ? 0 : this.items[0].leave_halfe_min;
    this.v_total026 = this.items[0].leave_halfe_total === undefined ? 0 : this.items[0].leave_halfe_total;
    this.qty03 = this.items[0].out_flow_qty === undefined ? 0 : this.items[0].out_flow_qty;
    this.qty03_sp = this.items[0].out_flow_qty_sp === undefined ? 0 : this.items[0].out_flow_qty_sp;
    this.min03 = this.items[0].out_flow_min === undefined ? 0 : this.items[0].out_flow_min;
    this.v_total03 = this.items[0].out_flow_total === undefined ? 0 : this.items[0].out_flow_total;
    this.qty04 = this.items[0].in_flow_qty === undefined ? 0 : this.items[0].in_flow_qty;
    this.qty04_sp = this.items[0].in_flow_qty_sp === undefined ? 0 : this.items[0].in_flow_qty_sp;
    this.min04 = this.items[0].in_flow_min === undefined ? 0 : this.items[0].in_flow_min;
    this.v_total04 = this.items[0].in_flow_total === undefined ? 0 : this.items[0].in_flow_total;
  }
  services4() {
    this.qty011 = 0;
    this.qty011_sp = 0;
    this.v_total011 = 0;
    this.qty012 = 0;
    this.qty012_sp = 0;
    this.v_total012 = 0;
    this.qty013 = 0;
    this.qty013_sp = 0;
    this.v_total013 = 0;
    this.qty014 = 0;
    this.qty014_sp = 0;
    this.min014 = 0;
    this.v_total014 = 0;
    this.qty021 = 0;
    this.qty021_sp = 0;
    this.v_total021 = 0;
    this.qty022 = 0;
    this.qty022_sp = 0;
    this.v_total022 = 0;
    this.qty023 = 0;
    this.qty023_sp = 0;
    this.v_total023 = 0;
    this.qty024 = 0;
    this.qty024_sp = 0;
    this.v_total024 = 0;
    this.qty025 = 0;
    this.qty025_sp = 0;
    this.min025 = 0;
    this.v_total025 = 0;
    this.qty026 = 0;
    this.qty026_sp = 0;
    this.min026 = 0;
    this.v_total026 = 0;
    this.qty03 = 0;
    this.qty03_sp = 0;
    this.min03 = 0;
    this.v_total03 = 0;
    this.qty04 = 0;
    this.qty04_sp = 0;
    this.min04 = 0;
    this.v_total04 = 0;
  }

  ngOnDestroy() {
    this.overtime_01 = this.ServiceJksService.clearovertime();
    this.overtime_02 = this.ServiceJksService.clearovertime();
    this.overtime_03 = this.ServiceJksService.clearovertime();
    this.overtime_04 = this.ServiceJksService.clearovertime();
    this.ServiceJksService.clearsv_over();
    this.items = this.ServiceJksService.clearservice_search();
  }
}

