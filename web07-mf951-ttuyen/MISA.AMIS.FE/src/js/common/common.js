import dayjs from "dayjs";

export const CommonFn = {
    /**
     * Hàm validate email đúng định dạng
     * @param {String} email 
     * @returns true: hợp lệ | false: không hợp lệ
     * CreateBy TTUyen ( 31/08/2021)
     */

    isEmail(email) {
        //eslint-disable-next-line
        var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    },

    /**
    * Hàm dùng để validate chỉ số
     * @param {String} string
     * @returns true: hợp lệ | false: không hợp lệ
     * CreatedBy:TTUyen (31/08/2021)
    */
    checkNumberOnly(string) {
        var numRegex = /^\d+$/;
        return numRegex.test(string);
    },

    /**
     * Hàm dùng để validate chỉ chữ và dấu cách
     * @param {String} string
     * @returns true: hợp lệ | false: không hợp lệ
     * CreatedBy:TTUyen (31/08/2021)
    */
    checkAlphabetOnly(string) {
        var alphaRegex = /^[a-zA-Z\s]*$/;
        return alphaRegex.test(string);
    },

    /**
     * Hàm format sang dạngn YYYY-MM-DD
     * @returns true: hợp lệ | false: không hợp lệ
     * CreateBy TTUyen ( 31/08/2021)
     */
    formatDateYMD(date) {
        if (date == null) {
            return new Date(date);
        }
        return dayjs(date).format("YYYY-MM-DD");
    },

    /**
 * Lấy số từ string
 * @param {*} str 
 * @returns converted string
 * CreateBy TTUyen ( 31/08/2021)
 */
    extractNumberFromString(str) {
        return str.replace(/[^0-9]/g, "");
    }

}


