var domBar = document.getElementById('containerBar');
var chartBar = echarts.init(domBar);

var opNames = [
	'OP10过渡套上料站',
	'OP20测滤网组装站',
	'OP30常开阀座组装站',
	'OP40过渡套收口压机站',
	'OP50过渡套孔深测量站',
	'OP60组装弹簧站',
	'OP70选配阀杆站',
	'OP80预压阀套站',
	'OP90精压阀套压机站',
	'OP100激光焊接阀套站',
	'OP110扫描二维码站',
	'OP120行程检测站',
	'OP130组装单向密封圈站',
	'OP140压装平面滤网站',
	'OP150总成高压测试站',
	'OP160总成低压测试'
];

var values = (
	function() {
		var res = [];
		var len = 16;
		while (len > 0) {
			// res.push((Math.random()*10 + 5).toFixed(1) - 0);
			res.push(random(300, 2000));
			len--;
		}
		return res;
})();

function random(min, max) {
	return Math.floor(Math.random() * (max - min)) + min;
}

var yields = (
	function() {
		var res = [];
		var len = 16;
		while (len > 0) {
			var rate = 0;
			while ((rate = random(0, 20)) > values[16 - len]);
			rate += random(0, 10) / 10.0;
			res.push(rate);
			len--;
		}
		return res;
})();

var bar = {
	series: [{
		type: 'bar',
		smooth: true,
		color: '#0bc9cb',
		// label: {
		// 	show: true,
		// 	position: 'outside'
		// },
		markPoint: {
			data: [{
				type: 'max',
				name: '产能最大值'
				// itemStyle: {
				// 	color: '#ff0000'
				// }
			}, {
				type: 'min',
				name: '产能最小值'
				// itemStyle: {
				// 	color: 'ff0000'
				// }
			}],
		},
		yAxisIndex: 0, // 第一根 Y 轴
		data: values
	}, {
		type: 'line',
		smooth: true,
		color: '#a27af0',
		markPoint: {
			data: [{
				type: 'max',
				name: '良率最大值'
				// itemStyle: {
				// 	color: '#ff0000'
				// }
			}, {
				type: 'min',
				name: '良率最小值'
				// itemStyle: {
				// 	color: 'ff0000'
				// }
			}],
		},
		yAxisIndex: 1, // 第二根 Y 轴
		data: yields
	}],
	xAxis: {
		type: 'category',
		// boundaryGap: false,
		axisLabel:{
			rotate: 60,	// 旋转标签
			fontWeight: "bold"
		},
		data: opNames,
	},
	yAxis: [{
		type: 'value',
		name: '产能',
		nameTextStyle: {
			fontSize: 15,
			fontWeight: "bold"
		},
		axisLabel:{
			color: '#0bc9cb'
		}
	}, {
		type: 'value',
		name: '良率/%',
		nameTextStyle: {
			fontSize: 15,
			fontWeight: "bold"
		},
		axisLabel: {
			color: '#a27af0',
			data: ['0', '20', '40', '60', '80', '100']
		},
		min: 0,			// Y 轴最小刻度
		max: 100,		// Y 轴最大刻度
		splitNumber: 5	// Y 轴细分
	}],
	grid: {
		top: 120,
		bottom: 120
	},
	title: {
		text: '常  开  阀  生  产  看  板',
		subtext: '近12小时产能&良率统计',
		left: "center",
		top: "top",
		textStyle: {
			fontSize: 30,
			fontStyle: 'normal',
			fontWeight: 'bolder',
			color: 'rgba(13, 146, 228, 1)'
		},
		subtextStyle: {
			fontSize: 20,
			fontStyle: 'normal',
			fontWeight: 'bolder',
			color: 'rgba(255, 0, 0, 1)'
		},
		itemGap: 30 // 设置主副标题之间的间距
	}
};

chartBar.setOption(bar)
