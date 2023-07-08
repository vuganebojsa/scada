import { Alarm } from "./Alarm"

export interface Tag{
    id?:number,
    tagName:string,
    description:string,
    ioAddress?:string,
    currentValue:number
}
export interface DigitalInput{
    id?:number,
    description:string,
    driver:string,
    ioAddress:string,
    scanTime:string,
    onOffScan:boolean
}

export interface DigitaOutput{
    id?:number,
    description:string,
    ioAddress:string,
    initialValue:number
}
export interface OutTagsDTO{
    id?:number,
    tagName:string,
    currentValue:number,
    
}

export interface AnalogInput{
    id?:number,
    description:string,
    driver:string,
    ioAddress:string,
    scanTime:string,
    alarms?:Alarm[],
    onOffScan:boolean,
    lowLimit:number,
    highLimit:number,
    units:string
}

export interface AnalogOutput{
    id?:number,
    description:string,
    ioAddress:string,
    initialValue:number,
    lowLimit:number,
    highLimit:number,
    units:string
}

export interface TagReportTimePeriodDTO{
    value:number,
    timestamp:Date,
    tagName: string
}