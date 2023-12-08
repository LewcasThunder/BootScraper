# BootScraper

## Table of Contents
- Command Line Arguments
- Output Format
- Planned Updated
- License

## Command Line Arguments

### Required
#### -serviceurl or -u 
Currently this needs to be set to "https://www.boots.com/online/psc/itemStock"

#### -productid or -p
Lisdexamfetamine:
- 20mg: 42013311000001109
- 30mg: 42013411000001102
- 40mg: 42013511000001103
- 50mg: 42013611000001104
- 60mg: 42013711000001108
- 70mg: 42013811000001100

If you want the codes for other medication (or spot any mistakes in the productids), feel free to reach out to me. Alternatively, you find the productid by doing a manual search for the medicine on the stock checker site using a browser's dev tools to monitor the search traffic. You can find the productid reference in the last of the three service requests.

### Optional
#### -output or -o
To specify the filepath/name for the output file. It defaults to "output.csv"

#### -requestdelay or -d
The delay in milliseconds between each API call. Defaults to 2000

#### -quiet or -q
Set to true to remove command line output. Defaults to false

## Output Format
It outputs in CSV format with the following structure:

AddressLine1, AddressLine2, AddressLine3, Postcode, StoreId, InStock

## Planned Updates

- Deduplicate the output data
- Search by County or City
- Search multiple chosen Counties or Cities
- Error handling
- Optional header on output file

## License
BootScraper is released under the [MIT license](https://github.com/LewcasThunder/BootScraper/blob/master/LICENSE)