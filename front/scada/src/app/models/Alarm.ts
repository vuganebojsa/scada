export interface Alarm{
    id?:number,
    type:string,
    threshold?:number,
    message?:string,
    timeOfActivation?:Date,
    timeStamp?:Date,
    measureUnit?:string,
    priority?:number,
    analogId?:number
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


