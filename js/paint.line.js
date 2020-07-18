var domLine = document.getElementById('containerLine');
var chartLine = echarts.init(domLine);

var dates = [
	'7-1',
	'7-2',
	'7-3',
	'7-4',
	'7-5',
	'7-6',
	'7-7',
	'7-8',
	'7-9',
	'7-10',
	'7-11',
	'7-12',
	'7-13',
	'7-14',
	'7-15',
	'7-16',
	'7-17',
	'7-18'
];

var values = (
	function() {
		var res = [];
		var len = 18;
		while (len > 0) {
			res.push((Math.random()*10 + 5).toFixed(1) - 0);
			len--;
		}
		return res;
})();

var line = {
	series: [{
		name: 'liner',
		type: 'line',
		symbol: 'none',
		smooth: true,
		areaStyle: {
			// color: '#fff',
			// origin: 'start',
			// shadowColor: '#F3F3F3',
			// shadowOffsetX: 1
		},
		// color: 'blue',
		data: values
	}],
	xAxis: {
		type: 'category',
		axisTick: {
			alignWithLabel: true // 刻度线和标签对齐
		},
		boundaryGap: false, // 取消“类目(category)”轴两边留白策略
		data: dates
	},
	yAxis: {
		// offset: -10 // y 轴在 x 轴上的偏移
	},
	grid: {
		top: 150,
		bottom: 130
	},
	title: {
		text: '常开线日产能统计',
		left: "center",
		top: "top",
		textStyle: {
			fontSize: 20,
			fontStyle: 'normal',
			fontWeight: 'bolder',
			color: 'rgba(255, 0, 0, 1)'
		},
		padding: 60
	}
};

chartLine.setOption(line);
