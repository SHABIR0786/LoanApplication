import { Pipe, PipeTransform } from "@angular/core";
/*
 * Raise the value exponentially
 * Takes an exponent argument that defaults to 1.
 * Usage:
 *   value | exponentialStrength:exponent
 * Example:
 *   {{ 2 | exponentialStrength:10 }}
 *   formats to: 1024
 */
@Pipe({ name: "ethnicityOtherValue" })
export class EthnicityOtherValuePipe implements PipeTransform {
  transform(value: any[], index: number): string {
    if (value === undefined || value === null || value.length === 0)
      return "--";
    return value[index].otherValue;
  }
}
