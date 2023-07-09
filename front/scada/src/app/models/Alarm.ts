export interface Alarm{
    id?:number,
    type:string,
    borderValue?:number,
    timeOfActivation:Date,
    measureUnit:string,
    priority?:number
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
