import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';



@Injectable()
export class CustomLogService {
  constructor() { }


  info(message: string) {
    console.log(`[custom] ${message}`);
  }
}
