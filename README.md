# BootScraper

## Table of Contents
- [Command Line Arguments](#command-line-arguments)
- [Output Format](#output-format)
- [Planned Updates](#planned-updates)
- [License](#license)

## Command Line Arguments

### Required
#### -serviceurl or -u 
Currently this needs to be set to "https://www.boots.com/online/psc/itemStock"

#### -inputstoredata or -i
The filepath/name of the store data input. This is currently located in "BootScraper.Queries\LoadStoreData\StoreData.csv"

#### -productid or -p
Lisdexamfetamine:
- 20mg: 42013311000001109
- 30mg: 42013411000001102
- 40mg: 42013511000001103
- 50mg: 42013611000001104
- 60mg: 42013711000001108
- 70mg: 42013811000001100

If you want the codes for other medication (or spot any mistakes in the productids above), feel free to reach out to me. Alternatively, you can find the productid by doing a manual search for the medicine on the stock checker site whilst using a web browser's dev tools to monitor the search traffic. You can find the productid reference in the last of the three service requests.

### Optional
#### -output or -o
Filepath/name for output file location. Will not output file if no value is given

#### -requestdelay or -r
The delay in milliseconds between each API call. Defaults to 10000 to help prevent getting locked out. Increase this if that still happens

#### -quiet or -q
Set to true to remove command line output. Defaults to false

#### -deduplicateoutput or -d
Set to true to produce an additional deduplicated output file. Defaults to false

#### -county or -c 
Sets the county to search for

## Output Format
It outputs in CSV format with the following structure:

AddressLine1, AddressLine2, AddressLine3, Postcode, StoreId, InStock, DateTimeChecked

## Planned Updates

- Search by City
- Search multiple chosen Counties or Cities
- Error handling
- Publish libraries to nuget.org

## License
BootScraper is released under the [MIT license](https://github.com/LewcasThunder/BootScraper/blob/master/LICENSE)