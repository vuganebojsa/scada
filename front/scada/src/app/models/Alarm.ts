export interface Alarm{
    id?:string,
    type:string,
    threshold?:number,
    message?:string,
    timeOfActivation?:Date,
    timeStamp?:Date,
    measureUnit?:string,
    priority?:number,
    analogId?:number
}
export interface ActivatedAlarm{
  id?:number,
  timestamp:Date,
  alarm?:Alarm,
  alarmId?:string
}
export interface ActivatedAlarmDTO{
  
  Timestamp:Date,
  Threshold:number,
  Message:string,
  Priority:number,
  Type:string,
  MeasureUnit:string
}
export interface AlarmPriorityDTO{
    type:string,
    timeOfActivation:Date,
    priority:number,
    tagName:string
}

export interface AlarmDTO{
  type:string,
  timeStamp:Date,
  priority:number,
  message:string,
  threshHold:number
}
export interface CreateAlarmDTO{
  analogId:number,
  threshold:number,
  message:string,
  priority:number,
  type:string
}


