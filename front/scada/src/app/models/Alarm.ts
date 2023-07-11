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
  timeStamp?:Date,
  alarm?:Alarm,
  alarmId?:string
  priority?:number,
  type?:string,
  measureUnit?:string
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
  threshold:number
}
export interface CreateAlarmDTO{
  analogId:number,
  threshold:number,
  message:string,
  priority:number,
  type:string
}


