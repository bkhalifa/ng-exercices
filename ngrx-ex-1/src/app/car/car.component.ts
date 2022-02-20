import { Component, Inject, OnInit } from '@angular/core';
import { CustomLog, ICustomLog } from '../shared/CustomLog';
import { CUSTOM_LOG, DATE_NOW } from '../shared/token';
import { LogService } from './log.service';

//change made after master , after branch feature A

// this is froù the branch : check this out

// chnage 2 master
@Component({
  selector: 'pm-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {
 name: string;

  constructor(private logService: LogService,
              @Inject(DATE_NOW) now: Date,
              @Inject('BILEL_NAME') name: string,
              @Inject(CUSTOM_LOG) private logger: CustomLog
             ) {
               console.log(`date now injection token :=> ${now.toString()}`)
              }


  ngOnInit(): void {
    this.logService.info('check this out')
    this.logger.info('Bilel is message');
  }

}
