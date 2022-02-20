import { Inject, Injectable } from '@angular/core';
import { LoggerConfig } from '../shared/logger-config';

@Injectable()
export class LogService {
  constructor(@Inject('logger.config') config: LoggerConfig) {
    console.log(config)
  }

  info = (message) => {
    console.log(`[Log]: ${message}`);
  }
}
